/* OggSong.cs
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
using NVorbis.OpenTKSupport;

namespace TriDevs.TriEngine.Audio
{
    /// <summary>
    /// Song class that can be used with <see cref="AudioManager" />.
    /// </summary>
    /// <remarks>
    /// The song class will stream from a specified file, instead of loading it into memory.
    /// </remarks>
    public class Song : ISong
    {
        private readonly string _name;
        private readonly string _file;

        private OggStream _stream;

        public string Name { get { return _name; } }
        public string File { get { return _file; } }

        public float Volume
        {
            get { return _stream.Volume; }
            set { _stream.Volume = Helpers.Math.Clamp(value, 0.0f, 1.0f); }
        }

        public bool IsLooped
        {
            get { return _stream.IsLooped; }
            set { _stream.IsLooped = value; }
        }

        internal Song(string name, string file, AudioFormat format = AudioFormat.Ogg)
        {
            if (format != AudioFormat.Ogg)
                throw new NotImplementedException("Support for formats other than ogg is not yet implemented.");

            _name = name;
            _file = file;

            try
            {
                _stream = new OggStream(_file);
                _stream.Prepare();
            }
            catch (InvalidDataException)
            {
                _stream.Dispose();
                _stream = new OggStream(_file);
                _stream.Prepare();
            }
        }

        public void Dispose()
        {
            if (_stream == null)
                return;

            Stop();
            _stream.Dispose();
            _stream = null;
        }
        
        public void Play()
        {
            try
            {
                _stream.Play();
            }
            catch (InvalidDataException)
            {
                Stop();
                Play();
            }
        }

        public void Stop()
        {
            _stream.Stop();
        }

        public void Pause()
        {
            _stream.Pause();
        }

        public void Resume()
        {
            _stream.Resume();
        }
    }
}
