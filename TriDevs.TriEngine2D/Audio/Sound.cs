/* Sound.cs
 *
 * Copyright © 2013 by Adam Hellberg, Sijmen Schoon and Preston Shumway.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.IO;
using System.Threading;
using OpenTK.Audio.OpenAL;

namespace TriDevs.TriEngine2D.Audio
{
    /// <summary>
    /// Sound class that can be used with the <see cref="AudioManager" />.
    /// </summary>
    public class Sound : ISound
    {
        private const int SourceCount = 16;
        private const int UpdateDelay = 200;

        private readonly string _name;
        private readonly string _file;

        private readonly int _buffer;
        private readonly int _channels;
        private readonly int _bitsPerSample;
        private readonly int _sampleRate;

        private readonly int[] _sources;
        private readonly ALSourceState[] _states;

        private readonly byte[] _data;

        // The update thread will take care of updating each source state
        // regularly (Playing, paused, stopped et.c)
        private readonly Thread _updateThread;

        private bool _active;

        public string Name { get { return _name; } }
        public string File { get { return _file; } }

        internal Sound(string name, string file, AudioFormat format = AudioFormat.Wav)
        {
            if (format != AudioFormat.Wav)
                throw new NotImplementedException("Support for formats other than WAVE has not yet been implemented.");

            _name = name;
            _file = file;

            // Generate a buffer
            _buffer = AL.GenBuffer();

            // Generate our sources
            _sources = AL.GenSources(SourceCount);

            // Create the states array
            _states = new ALSourceState[SourceCount];

            // Now read in our wave file
            _data = LoadWave(_file, out _channels, out _bitsPerSample, out _sampleRate);

            // Set up the buffer with our wave data
            AL.BufferData(_buffer, GetSoundFormat(_channels, _bitsPerSample), _data, _data.Length, _sampleRate);

            // Set up each individual source to use our buffer
            // We need multiple sources if we want to play multiple instances
            // of our wave at the same time.
            // We also get the initial source states here.
            for (var i = 0; i < SourceCount; i++)
            {
                AL.Source(_sources[i], ALSourcei.Buffer, _buffer);
                _states[i] = GetSourceState(_sources[i]);
            }

            // The sound is active!
            _active = true;

            // Start the update thread, we need updated states for our
            // "multiple simultaneus playback system" (TM) to work
            _updateThread = new Thread(ThreadUpdate) {Name = "SoundStateUpdate"};
            _updateThread.Start();
        }

        /// <summary>
        /// Gets the sound format based on number of channels and bits.
        /// </summary>
        /// <param name="channels">Number of channels.</param>
        /// <param name="bits">Bit count.</param>
        /// <returns>The <see cref="ALFormat" /> of this sound.</returns>
        /// <exception cref="NotSupportedException">Thrown if the format is not supported.</exception>
        private static ALFormat GetSoundFormat(int channels, int bits)
        {
            switch (channels)
            {
                case 1:
                    return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
                case 2:
                    return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
                default:
                    throw new NotSupportedException("The specified sound format is not supported.");
            }
        }

        private static ALSourceState GetSourceState(int source)
        {
            int state;
            AL.GetSource(source, ALGetSourcei.SourceState, out state);
            return (ALSourceState) state;
        }

        private static byte[] LoadWave(string file, out int channels, out int bits, out int rate)
        {
            return LoadWave(System.IO.File.OpenRead(file), out channels, out bits, out rate);
        }

        // LoadWave method from the OpenTK/OpenAL examples
        private static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
        {
            if (stream == null)
                throw new ArgumentNullException("stream", "Stream cannot be null.");

            using (var reader = new BinaryReader(stream))
            {
                // Quite a few of the variables we set here are not used
                // TODO: Scrap the assignment and just read into null?

                // RIFF header
                var signature = new string(reader.ReadChars(4));
                if (signature != "RIFF")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                var riffChunkSize = reader.ReadInt32();

                var format = new string(reader.ReadChars(4));
                if (format != "WAVE")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                // WAVE header
                var formatSignature = new string(reader.ReadChars(4));
                if (formatSignature != "fmt ")
                    throw new NotSupportedException("Specified wave file is not supported.");

                var formatChunkSize = reader.ReadInt32();
                var audioFormat = reader.ReadInt16();
                var numChannels = reader.ReadInt16();
                var sampleRate = reader.ReadInt32();
                var byteRate = reader.ReadInt32();
                var blockAlign = reader.ReadInt16();
                var bitsPerSample = reader.ReadInt16();

                var dataSignature = new string(reader.ReadChars(4));
                if (dataSignature != "data")
                    throw new NotSupportedException("Specified wave file is not supported.");

                var dataChunkSize = reader.ReadInt32();

                channels = numChannels;
                bits = bitsPerSample;
                rate = sampleRate;

                return reader.ReadBytes((int) reader.BaseStream.Length);
            }
        }

        private void UpdateStates()
        {
            for (var i = 0; i < SourceCount; i++)
                _states[i] = GetSourceState(_sources[i]);
        }

        private void ThreadUpdate()
        {
            try
            {
                while (_active)
                {
                    UpdateStates();
                    Thread.Sleep(UpdateDelay);
                }
            }
            catch (ThreadInterruptedException)
            {
                
            }
            catch (ThreadAbortException)
            {
                
            }
        }

        public void Play()
        {
            for (var i = 0; i < SourceCount; i++)
            {
                if (_states[i] != ALSourceState.Playing)
                {
                    AL.SourcePlay(_sources[i]);
                    return;
                }
            }
        }

        public void Stop()
        {
            for (var i = 0; i < SourceCount; i++)
                AL.SourceStop(_sources[i]);
        }

        public void Dispose()
        {
            _active = false;
            _updateThread.Join(UpdateDelay * 4);
            Stop();
            AL.DeleteSources(_sources);
            AL.DeleteBuffer(_buffer);
        }
    }
}
