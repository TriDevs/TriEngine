using System;
using System.Runtime.InteropServices;

namespace TriEngine2D.Native
{
	/// <summary>
	/// Holds various WinAPI stuff.
	/// </summary>
	public static class WinAPI
	{
// ReSharper disable InconsistentNaming
		// Functions

		/// <summary>
		/// Retrieves a handle to the specified standard device
		/// (standard input, standard output, or standard error).
		/// </summary>
		/// <param name="nStdHandle">The standard device.</param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the specified device,
		/// or a redirected handle set by a previous call to SetStdHandle.
		/// The handle has GENERIC_READ and GENERIC_WRITE access rights,
		/// unless the application has used SetStdHandle to set a standard handle with lesser access.
		/// If the function fails, the return value is INVALID_HANDLE_VALUE.
		/// To get extended error information, call GetLastError.
		/// If an application does not have associated standard handles,
		/// such as a service running on an interactive desktop,
		/// and has not redirected them, the return value is NULL.
		/// </returns>
		[DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr GetStdHandle(int nStdHandle);

		/// <summary>
		/// Allocates a new console for the calling process.
		/// </summary>
		/// <returns>
		/// If the function succeeds, the return value is nonzero.
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern bool AllocConsole();

		/// <summary>
		/// Detaches the calling process from its console.
		/// </summary>
		/// <returns>
		/// If the function succeeds, the return value is nonzero.
		/// If the function fails, the return value is zero.
		/// To get extended error information, call GetLastError.
		/// </returns>
		[DllImport("kernel32.dll", EntryPoint = "FreeConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern int FreeConsole();

		// Constants

		/// <summary>
		/// The standard output device. Initially, this is the active console screen buffer, CONOUT$.
		/// </summary>
		public const int STD_OUTPUT_HANDLE = -11;

		/// <summary>
		/// The code page to use for the console.
		/// </summary>
		public const int CODE_PAGE = 437;
// ReSharper restore InconsistentNaming
	}
}
