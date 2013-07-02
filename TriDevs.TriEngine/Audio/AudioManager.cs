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

using NVorbis.OpenTKSupport;
using OpenTK.Audio;
using TriDevs.TriEngine.Resources;

namespace TriDevs.TriEngine.Audio
{
    /// <summary>
    /// Class to manage engine audio.
    /// </summary>
    public class AudioManager : IAudioManager
    {
        private AudioContext _context;
        private OggStreamer _oggStreamer;

        /// <summary>
        /// Creates a new instance of <see cref="AudioManager" />.
        /// </summary>
        public AudioManager()
        {
            _context = new AudioContext();
            _oggStreamer = new OggStreamer();
        }

        public void Dispose()
        {
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

        public void StopAllSounds()
        {
            foreach (var sound in ResourceManager.GetAll<ISound>())
                sound.Stop();
        }

        public void StopAllSongs()
        {
            foreach (var song in ResourceManager.GetAll<ISong>())
                song.Stop();
        }
    }
}
