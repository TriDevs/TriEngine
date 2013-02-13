/* AudioManager.cs
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
using System.Collections.Generic;
using System.Linq;
using NVorbis.OpenTKSupport;
using OpenTK.Audio;

namespace TriDevs.TriEngine2D.Audio
{
    /// <summary>
    /// Class to manage engine audio.
    /// </summary>
    public class AudioManager : IAudioManager
    {
        private AudioContext _context;
        private OggStreamer _oggStreamer;

        private readonly List<ISound> _sounds;
        private readonly List<ISong> _songs; 

        /// <summary>
        /// Creates a new instance of <see cref="AudioManager" />.
        /// </summary>
        public AudioManager()
        {
            _context = new AudioContext();
            _oggStreamer = new OggStreamer();
            _sounds = new List<ISound>();
            _songs = new List<ISong>();
        }

        public void Dispose()
        {
            foreach (var sound in _sounds.Where(sound => sound != null))
                sound.Dispose();

            foreach (var song in _songs.Where(song => song != null))
                song.Dispose();

            if (_oggStreamer != null)
            {
                _oggStreamer.Dispose();
                _oggStreamer = null;
            }
            
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public void StopAll()
        {
            StopAllSounds();
            StopAllSongs();
        }

        public ISound LoadSound(string name, string file, AudioFormat format = AudioFormat.Wav)
        {
            var existing = _sounds.FirstOrDefault(s => s.Name == name);
            if (existing != null)
                return existing;

            var loaded = _sounds.FirstOrDefault(s => s.File == file) != null;
            if (loaded)
                throw new Exception("The sound file \"" + file + "\" has already been loaded under a different name.");

            var sound = new Sound(name, file, format);
            _sounds.Add(sound);
            return sound;
        }

        public bool HasSound(string name)
        {
            return _sounds.Any(s => s.Name == name);
        }

        public ISound GetSound(string name)
        {
            return _sounds.FirstOrDefault(s => s.Name == name);
        }

        public void StopAllSounds()
        {
            _sounds.ForEach(s => s.Stop());
        }

        public ISong LoadSong(string name, string file, AudioFormat format = AudioFormat.Ogg)
        {
            var existing = _songs.FirstOrDefault(s => s.Name == name);
            if (existing != null)
                return existing;

            var loaded = _songs.FirstOrDefault(s => s.File == file) != null;
            if (loaded)
                throw new Exception("The song file \"" + file + "\" has already been loaded under a different name.");

            var song = new Song(name, file, format);
            _songs.Add(song);
            return song;
        }

        public bool HasSong(string name)
        {
            return _songs.Any(s => s.Name == name);
        }

        public ISong GetSong(string name)
        {
            return _songs.FirstOrDefault(s => s.Name == name);
        }

        public void StopAllSongs()
        {
            _songs.ForEach(s => s.Stop());
        }
    }
}
