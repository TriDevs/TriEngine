/* Services.cs
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

using TriDevs.TriEngine2D.Audio;
using TriDevs.TriEngine2D.Input;

namespace TriDevs.TriEngine2D
{
    /// <summary>
    /// Provides different game-related service interfaces.
    /// </summary>
    /// <remarks>
    /// Actual service providers must be supplied from external code.
    /// All Service properties are intialized with Null-type services
    /// that provide no real functionality.
    /// </remarks>
    public static class Services
    {
        private static IInputManager _input = new NullInputManager();
        private static IAudioManager _audio = new NullAudioManager();

        /// <summary>
        /// The input manager service.
        /// </summary>
        public static IInputManager Input { get { return _input; } }

        /// <summary>
        /// The audio manager service.
        /// </summary>
        public static IAudioManager Audio { get { return _audio; } }

        /// <summary>
        /// Specifies an input manager service to provide.
        /// </summary>
        /// <param name="input">An object implementing the <see cref="IInputManager" /> interface.</param>
        public static void Provide(IInputManager input)
        {
            _input = input;
        }

        /// <summary>
        /// Specifies an audio manager service to provide.
        /// </summary>
        /// <param name="audio">An object implementing the <see cref="IAudioManager" /> interface.</param>
        public static void Provide(IAudioManager audio)
        {
            _audio = audio;
        }

		/// <summary>
		/// Specifies what services to provide.
		/// </summary>
		/// <param name="input">The input service to provide.</param>
		/// <param name="audio">The audio service to provide.</param>
		public static void Provide(IInputManager input, IAudioManager audio)
		{
			Provide(input);
			Provide(audio);
		}
    }
}
