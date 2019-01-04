using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.IO;

/// <summary>
/// namespace.
/// </summary>
namespace ItSoftware.TheMontyHallProblem
{	
	/// <summary>
	/// Main application class.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Static variables.
		/// </summary>
		internal static Random rnd1 = new Random(new Random().Next());
		internal static Random rnd2 = new Random(new Random().Next());
		internal static bool IsAKeyRead { get; set; } = false;
		internal static bool IsBreak { get; set; } = false;
		internal static DateTime StartDateTime { get; } = DateTime.Now;
		internal static bool IsNoChangeLogClosed { get; set; } = false;
		internal static bool IsChangeLogClosed { get; set; } = false;
		/// <summary>
		/// Appliation entry point.
		/// </summary>
		/// <param name="args"></param>
		internal static void Main(string[] args)
		{
			var consoleColor = Console.ForegroundColor;
			var cursorVisible = Console.CursorVisible;
			
			Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) =>
			{
				e.Cancel = true;
				IsBreak = true;
			};

			try
			{								
				var appArguments = new AppArguments(args);

				using (var load = new WorkLoad())
				{
					load.SampleSize = appArguments.SampleSize;

					if (!string.IsNullOrEmpty(appArguments.LogFileNoChange) && !string.IsNullOrWhiteSpace(appArguments.LogFileNoChange))
					{
						load.LogNoChange = new FileLogger(appArguments.LogFileNoChange);
					}

					if (!string.IsNullOrEmpty(appArguments.LogFileChange) && !string.IsNullOrWhiteSpace(appArguments.LogFileChange))
					{
						load.LogChange = new FileLogger(appArguments.LogFileChange);
					}

					var ui = new AppUI();
					ui.SampleSize = appArguments.SampleSize;
					ui.Initialize();

					ThreadPool.QueueUserWorkItem(WaitForIsAKeyRead, null);

					Task taskExecuteNoChange = Task.Run(() =>
				   {
					   return ExecuteNoChange(load);
				   });

					Task taskExecuteChange = Task.Run(() =>
				   {
					   return ExecuteChange(load);
				   });					

					do
					{
						ui.Update(load, StartDateTime);
					} while (!taskExecuteNoChange.IsCompleted || !taskExecuteChange.IsCompleted);

					ui.Update(load, StartDateTime);

					double run1Result = ((Convert.ToDouble(load.NoChange.Cars) * 100.0) / Convert.ToDouble(load.NoChange.Goats + load.NoChange.Cars));
					double run2Result = ((Convert.ToDouble(load.Change.Cars) * 100.0) / Convert.ToDouble(load.Change.Goats + load.Change.Cars));

					ui.RenderResult(run1Result, run2Result);

					Console.WriteLine("Simulation Complete");
					Console.WriteLine();
				}// using
			}
			catch ( ArgumentException )
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine();
				Console.WriteLine("## THE MONTY HALL PROBLEM (Two Goats and a Car)                      ##");
				Console.WriteLine("#######################################################################");
				Console.WriteLine("## Supported arguments:                                              ##");
				Console.WriteLine("##                                                                   ##");
				Console.WriteLine("## /SampleSize:<amount>                                              ##");
				Console.WriteLine("## Default=100                                                       ##");
				Console.WriteLine("## (i) The Number of times to execute the problem.                   ##");
				Console.WriteLine("##                                                                   ##");
				Console.WriteLine("## /LogFileChange:<filename>                                         ##");
				Console.WriteLine("## (i) Change Simulation log file. Only the first 1 000 000          ##");
				Console.WriteLine("##     simulations or less are written to log file.                  ##");
				Console.WriteLine("##                                                                   ##");
				Console.WriteLine("## /LogFileNoChange:<filename>                                       ##");
				Console.WriteLine("## (i) No Change Simulation log file. Only the first 1 000 000       ##");
				Console.WriteLine("##     simulations or less are written to log file.                  ##");
				Console.WriteLine("#######################################################################");
				Console.WriteLine();
			}			
			catch ( Exception x )
			{
				Console.WriteLine(x.ToString());
			}
			Console.ForegroundColor = consoleColor;
			Console.CursorVisible = cursorVisible;
		}
				
		/// <summary>
		/// A 'NoChange' simulation task.
		/// </summary>
		/// <param name="load"></param>
		private static Task ExecuteNoChange(WorkLoad load)
		{		
			for (var l = 0; l < load.SampleSize && !IsAKeyRead && !IsBreak; l++)
			{
				load.NoChange.Add(AttemtsToWinMonyHallNoChange(1, load));				

				if (Program.IsAKeyRead)
				{
					return Task.FromResult<bool>(false);
				}
			}			

			return Task.FromResult<bool>(true);
		}

		/// <summary>
		/// A 'Change' simulation task.
		/// </summary>
		/// <param name="load"></param>
		/// <returns></returns>
		private static Task ExecuteChange(WorkLoad load)
		{			
			for (var l = 0; l < load.SampleSize && !IsAKeyRead && !IsBreak; l++)
			{				
				load.Change.Add(AttemtsToWinMonyHallChange(1, load));

				if (Program.IsAKeyRead)
				{
					return Task.FromResult<bool>(false);
				}
			}

			return Task.FromResult<bool>(true);
		}
				
		/// <summary>
		/// Monitors for a key press.
		/// </summary>
		/// <param name="state"></param>
		private static void WaitForIsAKeyRead(object state)
		{
			Console.ReadKey();
			Program.IsAKeyRead = true;
		}

		/// <summary>
		/// Simulation routine. Attempts to win the monty hall with no change.
		/// </summary>
		/// <param name="numberOfAttempts"></param>
		/// <returns></returns>
		private static Statistics AttemtsToWinMonyHallNoChange(long numberOfAttempts, WorkLoad load)
		{
			Statistics stats = new Statistics();

			if (numberOfAttempts <= 0)
			{
				return stats;
			}
			
			for ( long l = 0; l < numberOfAttempts; l++ )
			{
				int seed = rnd1.Next(1, 4);
				char[] doors = new char[3];
				switch (seed)
				{
					case 1:					
						doors[0] = 'G';
						doors[1] = 'G';
						doors[2] = 'C';
						break;
					case 2:					
						doors[0] = 'G';
						doors[1] = 'C';
						doors[2] = 'G';
						break;
					case 3:					
						doors[0] = 'C';
						doors[1] = 'G';
						doors[2] = 'G';
						break;
					default:
						break;
				}// switch

				// 1. round
				int round1 = rnd1.Next(1, 4);
				switch (doors[round1-1])
				{
					case 'G':
						stats.Goats = stats.Goats + 1;
						switch (round1)
						{
							case 1:
								stats.Door1Goats = stats.Door1Goats + 1;
								break;
							case 2:
								stats.Door2Goats = stats.Door2Goats + 1;
								break;
							case 3:
								stats.Door3Goats = stats.Door3Goats + 1;
								break;
							default:
								break;
						}
						break;
					case 'C':
						stats.Cars = stats.Cars + 1;
						switch (round1)
						{
							case 1:
								stats.Door1Hits = stats.Door1 + 1;
								break;
							case 2:
								stats.Door2Hits = stats.Door2 + 1;
								break;
							case 3:
								stats.Door3Hits = stats.Door3 + 1;
								break;
							default:
								break;
						}
						break;
					default:
						break;
				}// switch

				long count = load.NoChange.Goats + load.NoChange.Cars + 1;

				if (load.LogNoChange != null && !IsNoChangeLogClosed )
				{
					if (count <= 1_000_000)
					{
						load.LogNoChange.WriteTo(RenderLogText(doors, round1 - 1, count));
					}
					else
					{
						load.LogNoChange.Dispose();
						IsNoChangeLogClosed = true;
					}
				}

				switch (round1)
				{
					case 1:
						stats.Door1 = stats.Door1 + 1;
						break;
					case 2:
						stats.Door2 = stats.Door2 + 1;
						break;
					case 3:
						stats.Door3 = stats.Door3 + 1;
						break;
					default:
						break;
				}
			}

			return stats;
		}

		/// <summary>
		/// Simulation routine. Attempts to win the monty hall with change.
		/// </summary>
		/// <param name="numberOfAttempts"></param>
		/// <returns></returns>
		private static Statistics AttemtsToWinMonyHallChange(long numberOfAttempts, WorkLoad load)
		{
			Statistics stats = new Statistics();

			if ( numberOfAttempts <= 0 )
			{
				return stats;
			}		

			for (long l = 0; l < numberOfAttempts; l++)
			{
				int seed = rnd2.Next(1, 4);
				char[] doors = new char[3];
				switch (seed)
				{				
					case 1:					
						doors[0] = 'G';
						doors[1] = 'G';
						doors[2] = 'C';
						break;
					case 2:					
						doors[0] = 'G';
						doors[1] = 'C';
						doors[2] = 'G';
						break;
					case 3:					
						doors[0] = 'C';
						doors[1] = 'G';
						doors[2] = 'G';
						break;
					default:
						break;
				}// switch

				// 1. round
				int round1 = rnd2.Next(1, 4);
				int remove1 = rnd2.Next(1, 4);
				while ( remove1 == round1 || doors[remove1-1] == 'C')
				{
					remove1 = rnd2.Next(1, 4);
				}

				int round2 = -1;
				if ( round1 == 1 && remove1 == 2 )
				{
					round2 = 3;
				}
				else if ( round1 == 1 && remove1 == 3 )
				{
					round2 = 2;
				}
				else if ( round1 == 2 && remove1 == 1 )
				{
					round2 = 3;
				}
				else if ( round1 == 2 && remove1 == 3 )
				{
					round2 = 1;
				}
				else if ( round1 == 3 && remove1 == 1 )
				{
					round2 = 2;
				}
				else if ( round1 == 3 && remove1 == 2 )
				{
					round2 = 1;
				}
				

				switch (doors[round2 - 1])
				{
					case 'G':
						stats.Goats = stats.Goats + 1;
						switch (round2)
						{
							case 1:
								stats.Door1Goats = stats.Door1Goats + 1;
								break;
							case 2:
								stats.Door2Goats = stats.Door2Goats + 1;
								break;
							case 3:
								stats.Door3Goats = stats.Door3Goats + 1;
								break;
							default:
								break;
						}
						break;
					case 'C':
						stats.Cars = stats.Cars + 1;
						switch (round2)
						{
							case 1:
								stats.Door1Hits = stats.Door1Hits + 1;
								break;
							case 2:
								stats.Door2Hits = stats.Door2Hits + 1;
								break;
							case 3:
								stats.Door3Hits = stats.Door3Hits + 1;
								break;
							default:
								break;
						}
						break;
					default:
						break;
				}// switch

				long count = load.Change.Goats + load.Change.Cars + 1;

				if (load.LogChange != null && !IsChangeLogClosed )
				{
					if (count <= 1_000_000)
					{
						load.LogChange.WriteTo(RenderLogText(doors, round1 - 1, count));
					}
					else
					{						
						load.LogChange.Dispose();
						IsChangeLogClosed = true;
					}
				}

				switch ( round2 )
				{
					case 1:
						stats.Door1 = stats.Door1 + 1;
						break;
					case 2:
						stats.Door2 = stats.Door2 + 1;
						break;
					case 3:
						stats.Door3 = stats.Door3 + 1;
						break;
					default:
						break;
				}				
			}

			return stats;
		}

		internal static string RenderLogText(char[] doors, int selectedDoor, long logNumber)
		{
			var text = new StringBuilder();

			text.AppendLine($"#{logNumber}");
			text.AppendLine($"[{doors[0]},{doors[1]},{doors[2]}] - selected door {selectedDoor+1} | {doors[selectedDoor]}");

			return text.ToString();
		}
	}// class
}// namespace
