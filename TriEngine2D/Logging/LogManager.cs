using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using TriDevs.TriEngine2D.Native;
using log4net;
using log4net.Config;

namespace TriDevs.TriEngine2D.Logging
{
	/// <summary>
	/// Class to manage logging.
	/// ILog interfaces should be obtained from this class' methods,
	/// as opposed to calling default log4net methods.
	/// </summary>
	public static class LogManager
	{
		private static bool _loaded;
		private static bool _consoleLoaded;

		/// <summary>
		/// Load a config to use with log4net.
		/// </summary>
		/// <remarks>
		/// LoadConfig will first try to load the specified file, if not null.
		/// If it is unable to find the specified file, it will call itself again with file set to null.
		/// If no file is specified, it will attempt to load a config file following the pattern:
		/// "(AssemblyName).config"
		/// If it is unable to load the config, it will default to <see cref="BasicConfigurator" />.
		/// </remarks>
		/// <param name="file">The config file to load, null if automatic loading is preferred.</param>
		public static void LoadConfig(string file = null)
		{
			if (file == null)
			{
				if (File.Exists(AppDomain.CurrentDomain.FriendlyName + ".config"))
					XmlConfigurator.Configure();
				else
					BasicConfigurator.Configure();
			}
			else
			{
				if (File.Exists(file))
					XmlConfigurator.Configure(new FileInfo(file));
				else
				{
					LoadConfig();
					return;
				}
			}

			_loaded = true;
		}

		/// <summary>
		/// Gets an <see cref="ILog" /> object for the specified object.
		/// </summary>
		/// <remarks>
		/// To get the logger object for a static class, or from static context,
		/// call GetLogger(typeof(YourClass)).
		/// </remarks>
		/// <param name="sender">The object or <see cref="Type" /> to get an <see cref="ILog" /> object for.</param>
		/// <returns>The <see cref="ILog" /> object.</returns>
		public static ILog GetLogger(object sender)
		{
			if (!_loaded)
				LoadConfig();

			return log4net.LogManager.GetLogger(sender.GetType().ToString() == "System.RuntimeType" ? (Type)sender : sender.GetType());
		}

		/// <summary>
		/// Set up a new console for this process.
		/// Will not set up a console if a debugger is attached.
		/// This method does nothing if DEBUG is not #defined.
		/// </summary>
		public static void SetupConsole()
		{
#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached)
				return;

			WinAPI.AllocConsole();
			var stdHandle = WinAPI.GetStdHandle(WinAPI.STD_OUTPUT_HANDLE);
			var safeFileHandle = new SafeFileHandle(stdHandle, true);
			var fileStream = new FileStream(safeFileHandle, FileAccess.Write);
			var encoding = Encoding.GetEncoding(WinAPI.CODE_PAGE);
			var stdOut = new StreamWriter(fileStream, encoding) { AutoFlush = true };
			Console.SetOut(stdOut);
			_consoleLoaded = true;
#endif
		}

		/// <summary>
		/// Destroys the console associated with the process, if loaded.
		/// This method does nothing if DEBUG is not #defined.
		/// </summary>
		public static void DestroyConsole()
		{
#if DEBUG
			if (_consoleLoaded)
				WinAPI.FreeConsole();
#endif
		}

		/// <summary>
		/// Clear logs that are older than the specified amount of days.
		/// </summary>
		/// <param name="daysOld">Logs older than this amount of days will be deleted.</param>
		/// <param name="logsDir">The directory to clear.</param>
		public static void ClearOldLogs(int daysOld = 7, string logsDir = "logs")
		{
			var log = GetLogger(typeof(LogManager));

			log.InfoFormat(">> ClearOldLogs({0}, \"{1}\")", daysOld, logsDir);

			if (!Directory.Exists(logsDir))
			{
				log.InfoFormat("Directory {0} not found, no logs to clear", logsDir);
				log.Info("<< ClearOldLogs()");
				return;
			}

			var now = DateTime.Now;
			var max = new TimeSpan(daysOld, 0, 0, 0);
			var count = 0;
			foreach (var file in from file in Directory.GetFiles(logsDir)
								 let modTime = File.GetLastAccessTime(file)
								 let age = now.Subtract(modTime)
								 where age > max
								 select file)
			{
				try
				{
					File.Delete(file);
					log.InfoFormat("Deleted old log file: {0}", file);
					count++;
				}
				catch (IOException ex)
				{
					log.WarnFormat("Failed to delete log file: {0} ({1})", file, ex.Message);
				}
			}

			log.InfoFormat("Done! Cleared {0} log files.", count);
			log.Info("<< ClearOldLogs()");
		}
	}
}
