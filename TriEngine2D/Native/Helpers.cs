using System.ComponentModel;
using System.Runtime.InteropServices;

namespace TriEngine2D.Native
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
			return Marshal.GetLastWin32Error();
		}

		/// <summary>
		/// Gets information about the last error that was thrown.
		/// </summary>
		/// <param name="message">Will be set to the error message.</param>
		/// <returns>The error code associated with the thrown error.</returns>
		public static int GetLastErrorInfo(out string message)
		{
			var err = GetLastError();
			message = GetWin32Exception(err).Message;
			return err;
		}

		/// <summary>
		/// Gets the error message associated with an error code.
		/// </summary>
		/// <param name="err">The error code to get information about.</param>
		/// <returns>The error message.</returns>
		public static string GetErrorMessage(int err)
		{
			return GetWin32Exception(err).Message;
		}

		/// <summary>
		/// Gets the error message associated with the last thrown error.
		/// </summary>
		/// <returns>The error message.</returns>
		public static string GetLastErrorMessage()
		{
			return GetErrorMessage(GetLastError());
		}

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
	}
}
