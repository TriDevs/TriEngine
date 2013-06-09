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

using System;

namespace TriDevs.TriEngine.Audio
{
    /// <summary>
    /// Provides various methods to manipulate audio.
    /// </summary>
    public interface IAudioManager : IDisposable
    {
        /// <summary>
        /// Immediately stops all playback of sounds and songs.
        /// </summary>
        void StopAll();

        /// <summary>
        /// Loads a sound into the audio manager.
        /// </summary>
        /// <remarks>
        /// If a sound with the same name has already been loaded,
        /// it will be returned instead.
        /// </remarks>
        /// <param name="name">Name to assign to the new sound object.</param>
        /// <param name="file">Path to the file that will be used.</param>
        /// <param name="format">The format of the file to load.</param>
        /// <returns>The resulting object implementing the <see cref="ISound" /> interface.</returns>
        ISound LoadSound(string name, string file, AudioFormat format = AudioFormat.Wav);

        /// <summary>
        /// Returns a value indicating whether a sound with the specified name has been loaded
        /// into the audio manager.
        /// </summary>
        /// <param name="name">Name to check for.</param>
        /// <returns>True if the sound has been loaded, false otherwise.</returns>
        bool HasSound(string name);

        /// <summary>
        /// Gets the sound with the specified name.
        /// </summary>
        /// <param name="name">Name of the sound to get.</param>
        /// <returns>
        /// An object implementing the <see cref="ISound" /> interface,
        /// or null if no sound matched the requested name.
        /// </returns>
        ISound GetSound(string name);

        /// <summary>
        /// Immediately stops playback of all sounds.
        /// </summary>
        void StopAllSounds();

        /// <summary>
        /// Load a song into the audio manager.
        /// </summary>
        /// <remarks>
        /// If a song with the same name has already been loaded,
        /// it will be returned instead.
        /// </remarks>
        /// <param name="name">Name to assign to the new song object.</param>
        /// <param name="file">Path to the file that will be used.</param>
        /// <param name="format">Format of the file.</param>
        /// <returns>The resulting object implementing the <see cref="ISong" /> interface.</returns>
        ISong LoadSong(string name, string file, AudioFormat format = AudioFormat.Ogg);

        /// <summary>
        /// Returns a value indicating whether a song with the specified name has been loaded into the audio manager.
        /// </summary>
        /// <param name="name">Name to check for.</param>
        /// <returns>True if the song has been loaded, false otherwise.</returns>
        bool HasSong(string name);

        /// <summary>
        /// Gets the song with the specified name.
        /// </summary>
        /// <param name="name">Name of the song to get.</param>
        /// <returns>
        /// An object implementing the <see cref="ISong" /> interface, 
        /// or null if no song matched the requested name.
        /// </returns>
        ISong GetSong(string name);

        /// <summary>
        /// Immediately stops playback of all songs.
        /// </summary>
        void StopAllSongs();
    }
}
