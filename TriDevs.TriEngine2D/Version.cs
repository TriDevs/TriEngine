/* Version.cs
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

namespace TriDevs.TriEngine2D
{
	/// <summary>
	/// Version class specifiying the version of this project.
	/// </summary>
	public static class Version
	{
		/// <summary>
		/// Major version of the project.
		/// </summary>
		public const int Major = 0;

		/// <summary>
		/// Minor version of the project.
		/// </summary>
		public const int Minor = 0;

		/// <summary>
		/// Patch version of the project.
		/// </summary>
		public const int Patch = 2;

		/// <summary>
		/// Optional suffix, empty if no suffix for this version.
		/// </summary>
		/// <remarks>
		/// Example values could be "beta" and "alpha".
		/// </remarks>
		public const string Suffix = "";

		/// <summary>
		/// The format string used when formatting major, minor and patch version
		/// to their string representation.
		/// </summary>
		public const string VersionStringFormat = "{0}.{1}.{2}";

		/// <summary>
		/// The format string used when formatting major, minor and patch version
		/// to their string representation (with suffix).
		/// </summary>
		public const string VersionStringFormatWithSuffix = VersionStringFormat + "-{3}";

		/// <summary>
		/// String representation of the current project version.
		/// </summary>
		public static string VersionString
		{
			get
			{
				return string.Format(string.IsNullOrEmpty(Suffix) ? VersionStringFormat : VersionStringFormatWithSuffix, Major, Minor, Patch, Suffix);
			}
		}
	}
}
