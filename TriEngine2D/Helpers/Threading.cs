using System.Threading;

namespace TriDevs.TriEngine2D.Helpers
{
	/// <summary>
	/// Provides various helper functions for doing threading operations.
	/// </summary>
	public static class Threading
	{
		/// <summary>
		/// Sets the name of the current thread,
		/// does nothing if the thread already has a name.
		/// </summary>
		/// <param name="name">The new name for the current thread</param>
		public static void SetCurrentThreadName(string name)
		{
			// We can't set the name on a thread if it's already set, it would throw an exception
			// So we have to check if the current name is null before trying to set a new one
			if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
				Thread.CurrentThread.Name = name;
		}
	}
}
