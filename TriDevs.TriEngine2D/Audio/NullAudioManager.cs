/* IAudioManager.cs
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

namespace TriDevs.TriEngine2D.Audio
{
    /// <summary>
    /// Used as a fallback AudioManager object when the service locator fails to find one.
    /// </summary>
    public class NullAudioManager : IAudioManager
    {
        private static readonly ISound Sound = new NullSound();
        private static readonly ISong Song = new NullSong();

        public void Dispose()
        {
            
        }

        public void StopAll()
        {
            
        }

        public ISound LoadSound(string name, string file, AudioFormat format = AudioFormat.Wav)
        {
            return Sound;
        }

        public bool HasSound(string name)
        {
            return false;
        }

        public ISound GetSound(string name)
        {
            return Sound;
        }

        public void StopAllSounds()
        {
            
        }

        public ISong LoadSong(string name, string file, AudioFormat format = AudioFormat.Ogg)
        {
            return Song;
        }

        public bool HasSong(string name)
        {
            return false;
        }

        public ISong GetSong(string name)
        {
            return Song;
        }

        public void StopAllSongs()
        {
            
        }
    }
}
