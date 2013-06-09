/* ISong.cs
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
    /// A song that will be streamed in the audio player.
    /// </summary>
    public interface ISong : IDisposable
    {
        /// <summary>
        /// Gets the name associated with this song.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the file this song was loaded from.
        /// </summary>
        string File { get; }

        /// <summary>
        /// Gets or sets the song volume.
        /// </summary>
        float Volume { get; set; }

        /// <summary>
        /// Gets or sets a value indicating that the song should be looped
        /// once it reaches the end.
        /// </summary>
        bool IsLooped { get; set; }

        /// <summary>
        /// Starts playback of the song.
        /// </summary>
        void Play();

        /// <summary>
        /// Stops playback of the song.
        /// </summary>
        void Stop();

        /// <summary>
        /// Pauses playback of the song.
        /// </summary>
        /// <remarks>
        /// Call the <see cref="Resume" /> or <see cref="Play" /> method to resume playback.
        /// </remarks>
        void Pause();

        /// <summary>
        /// Resumes playback of a paused song.
        /// </summary>
        void Resume();
    }
}
