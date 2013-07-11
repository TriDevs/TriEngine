/* Helpers.cs
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

// TODO: Implementations for other OS platforms

#if WINDOWS
using System.ComponentModel;
using System.Runtime.InteropServices;
#endif

namespace TriDevs.TriEngine.Native
{
    /// <summary>
    /// Helper class with various methods to help native coding and debugging.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Gets the last error that was thrown.
        /// </summary>
        /// <returns>The error code associated with the thrown error.</returns>
        public static int GetLastError()
        {
#if WINDOWS
            return Marshal.GetLastWin32Error();
#else
            throw new System.NotImplementedException();
#endif
        }

        /// <summary>
        /// Gets information about the last error that was thrown.
        /// </summary>
        /// <param name="message">Will be set to the error message.</param>
        /// <returns>The error code associated with the thrown error.</returns>
        public static int GetLastErrorInfo(out string message)
        {
            var err = GetLastError();
#if WINDOWS
            message = GetWin32Exception(err).Message;
#else
            throw new System.NotImplementedException();
#endif
            return err;
        }

        /// <summary>
        /// Gets the error message associated with an error code.
        /// </summary>
        /// <param name="err">The error code to get information about.</param>
        /// <returns>The error message.</returns>
        public static string GetErrorMessage(int err)
        {
#if WINDOWS
            return GetWin32Exception(err).Message;
#else
            throw new System.NotImplementedException();
#endif
        }

        /// <summary>
        /// Gets the error message associated with the last thrown error.
        /// </summary>
        /// <returns>The error message.</returns>
        public static string GetLastErrorMessage()
        {
            return GetErrorMessage(GetLastError());
        }

#if WINDOWS
        /// <summary>
        /// Gets the <see cref="Win32Exception" /> associated with the specified error code.
        /// </summary>
        /// <param name="err">The error code.</param>
        /// <returns>The <see cref="Win32Exception" /> for the provided error code.</returns>
        public static Win32Exception GetWin32Exception(int err)
        {
            return new Win32Exception(err);
        }

        /// <summary>
        /// Gets the <see cref="Win32Exception" /> associated with the last thrown error.
        /// </summary>
        /// <returns>The <see cref="Win32Exception" />.</returns>
        public static Win32Exception GetLastWin32Exception()
        {
            return GetWin32Exception(GetLastError());
        }
#endif
    }
}
