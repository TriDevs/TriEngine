using System.IO;

namespace TriEngine2D.Helpers
{
	/// <summary>
	/// Provides various helper functions for doing IO operations.
	/// </summary>
	public static class IO
	{
		/// <summary>
		/// Resolves the absolute path from a relative path.
		/// </summary>
		/// <param name="path">The relative path to resolve.</param>
		/// <returns>The absolute path to the item.</returns>
		public static string GetAbsolutePath(string path)
		{
			return Path.Combine(Directory.GetCurrentDirectory(), path);
		}
	}
}
