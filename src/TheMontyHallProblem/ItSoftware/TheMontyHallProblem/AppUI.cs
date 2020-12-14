using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/// <summary>
/// namespace.
/// </summary>
namespace ItSoftware.TheMontyHallProblem
{
	/// <summary>
	/// The application UI.
	/// </summary>
	internal class AppUI
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		internal AppUI()
		{

		}

		/// <summary>
		/// Internal properties.
		/// </summary>
		internal long SampleSize { get; set; } = 100;
		internal ConsoleColor NumberColor { get; set; } = ConsoleColor.Yellow;
		internal ConsoleColor SkeletonColor { get; set; } = ConsoleColor.DarkGray;
		internal ConsoleColor PressAnyKeyToStopColor { get; set; } = ConsoleColor.White;
		internal CultureInfo UICultureInfo { get; set; } = new CultureInfo("nb-NO");

		/// <summary>
		/// Initializes UI.
		/// </summary>
		internal void Initialize()
		{
			Console.Clear();
			Console.CursorVisible = false;

			RenderSkeleton();
			RenderPressAnyKeyToStop();

			RenderSampleSize();
			RenderProgressNoChange(0, 0, this.SampleSize);
			RenderProgressChange(0, 0, this.SampleSize);
		}

		/// <summary>
		/// Renders UI skeleton.
		/// </summary>
		private void RenderSkeleton()
		{
			Console.SetCursorPosition(0, 0);
			Console.ForegroundColor = this.SkeletonColor;

			Console.WriteLine("## THE MONTY HALL PROBLEM (Two Goats and a Car)                                                    ##");
			Console.WriteLine("#####################################################################################################");
			Console.WriteLine("## Sample Size:                                                                                    ##");
			Console.WriteLine("## Time Elapsed:                                                                                   ##");
			Console.WriteLine("#####################################################################################################");
			Console.WriteLine("## No Change Simulation #############################################################################");
			Console.WriteLine("## Progress:                                                                                       ##");
			Console.WriteLine("## Cars:                                                                                           ##");
			Console.WriteLine("## Goats:                                                                                          ##");
			Console.WriteLine("## Door 1:                                                                                         ##");
			Console.WriteLine("## Door 2:                                                                                         ##");
			Console.WriteLine("## Door 3:                                                                                         ##");
			Console.WriteLine("#####################################################################################################");
			Console.WriteLine("## Change Simulation    #############################################################################");
			Console.WriteLine("## Progress:                                                                                       ##");
			Console.WriteLine("## Cars:                                                                                           ##");
			Console.WriteLine("## Goats:                                                                                          ##");
			Console.WriteLine("## Door 1:                                                                                         ##");
			Console.WriteLine("## Door 2:                                                                                         ##");
			Console.WriteLine("## Door 3:                                                                                         ##");
			Console.WriteLine("#####################################################################################################");
			Console.WriteLine("## Winner:                                                                                         ##");
			Console.WriteLine("#####################################################################################################");

			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(3, 0);
			Console.Write("THE MONTY HALL PROBLEM (Two Goats and a Car)");
			Console.SetCursorPosition(3, 2);
			Console.Write("Sample Size:");
			Console.SetCursorPosition(3, 3);
			Console.Write("Time Elapsed:");
			Console.SetCursorPosition(3, 5);
			Console.Write("No Change Simulation");
			Console.SetCursorPosition(3, 6);
			Console.Write("Progress:");
			Console.SetCursorPosition(3, 7);
			Console.Write("Cars:");
			Console.SetCursorPosition(3, 8);
			Console.Write("Goats:");
			Console.SetCursorPosition(3, 9);
			Console.Write("Door 1:");
			Console.SetCursorPosition(3, 10);
			Console.Write("Door 2:");
			Console.SetCursorPosition(3, 11);
			Console.Write("Door 3:");
			Console.SetCursorPosition(3, 13);
			Console.Write("Change Simulation");
			Console.SetCursorPosition(3, 14);
			Console.Write("Progress:");
			Console.SetCursorPosition(3, 15);
			Console.Write("Cars:");
			Console.SetCursorPosition(3, 16);
			Console.Write("Goats:");
			Console.SetCursorPosition(3, 17);
			Console.Write("Door 1:");
			Console.SetCursorPosition(3, 18);
			Console.Write("Door 2:");
			Console.SetCursorPosition(3, 19);
			Console.Write("Door 3:");
			Console.SetCursorPosition(3, 21);
			Console.Write("Winner:");
		}

		/// <summary>
		/// Renders 'Press any key to stop...'.
		/// </summary>
		private void RenderPressAnyKeyToStop()
		{
			Console.SetCursorPosition(0, 24);
			Console.ForegroundColor = this.PressAnyKeyToStopColor;
			Console.WriteLine("Press any key to stop...");
		}

		/// <summary>
		/// Renders SampleSize.
		/// </summary>
		private void RenderSampleSize()
		{
			Console.SetCursorPosition(17, 2);
			Console.ForegroundColor = this.NumberColor;
			Console.Write($"{ this.SampleSize.ToString("n", this.UICultureInfo).Replace(",00", "")}");
		}

		/// <summary>
		/// Renders progress of NoChange simulation.
		/// </summary>
		/// <param name="progress"></param>
		/// <param name="runs"></param>
		/// <param name="runsOutOf"></param>
		internal void RenderProgressNoChange(double progress, long runs, long runsOutOf)
		{
			int iLeft = Console.CursorLeft;
			int iTop = Console.CursorTop;

			Console.SetCursorPosition(65, 5);

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("│");

			int steps = Convert.ToInt32(progress / 3.3333);

			Console.ForegroundColor = ConsoleColor.Yellow;
			for (int i = 0; i < steps; i++)
			{
				Console.Write("█");
			}
			Console.ForegroundColor = ConsoleColor.White;

			for (int j = steps; j < 30; j++)
			{
				Console.Write("░");
			}
			Console.Write("│");

			Console.SetCursorPosition(17, 6);

			Console.ForegroundColor = this.NumberColor;
			Console.Write($"{progress.ToString("0.00")}%");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" | ");
			Console.ForegroundColor = this.NumberColor;
			Console.Write($"{ runs.ToString("n", this.UICultureInfo).Replace(",00", "")}");			

			Console.SetCursorPosition(iLeft, iTop);
		}

		/// <summary>
		/// Renders progress of Change simulation.
		/// </summary>
		/// <param name="progress"></param>
		/// <param name="runs"></param>
		/// <param name="runsOutOf"></param>
		internal void RenderProgressChange(double progress, long runs, long runsOutOf)
		{
			int iLeft = Console.CursorLeft;
			int iTop = Console.CursorTop;

			Console.SetCursorPosition(65, 13);

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("│");

			int steps = Convert.ToInt32(progress / 3.3333);

			Console.ForegroundColor = ConsoleColor.Yellow;
			for (int i = 0; i < steps; i++)
			{
				Console.Write("█");
			}
			Console.ForegroundColor = ConsoleColor.White;

			for (int j = steps; j < 30; j++)
			{
				Console.Write("░");
			}
			Console.Write("│");

			Console.SetCursorPosition(17, 14);

			Console.ForegroundColor = this.NumberColor;
			Console.Write($"{progress.ToString("0.00")}%");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" | ");
			Console.ForegroundColor = this.NumberColor;
			Console.Write($"{ runs.ToString("n", this.UICultureInfo).Replace(",00", "")}");			

			Console.SetCursorPosition(iLeft, iTop);
		}

		/// <summary>
		/// Updates running information.
		/// </summary>
		/// <param name="load"></param>
		/// <param name="dtStarted"></param>
		internal void Update(WorkLoad load, DateTime dtStarted)
		{
			//
			// Render Progress
			//
			double percentRun1 = (Convert.ToDouble(load.NoChange.Goats + load.NoChange.Cars) * 100.0 / Convert.ToDouble(this.SampleSize));
			double percentRun2 = (Convert.ToDouble(load.Change.Goats + load.Change.Cars) * 100.0 / Convert.ToDouble(this.SampleSize));

			RenderProgressNoChange(percentRun1, load.NoChange.Goats + load.NoChange.Cars, load.SampleSize);
			RenderProgressChange(percentRun2, load.Change.Cars + load.Change.Goats, load.SampleSize);
			
			//
			// Render Goats and Cars
			//
			long additional1 = load.NoChange.Goats + load.NoChange.Cars;
			if (additional1 <= 0)
			{
				additional1 = 1;
			}
			else
			{
				additional1 = 0;
			}

			long additional2 = load.Change.Goats + load.Change.Cars;
			if (additional2 <= 0)
			{
				additional2 = 1;
			}
			else
			{
				additional2 = 0;
			}

			Console.SetCursorPosition(17, 7);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Cars.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ ((Convert.ToDouble(load.NoChange.Cars) * 100.0) / Convert.ToDouble(load.NoChange.Goats + load.NoChange.Cars + additional1)).ToString("0.00") }%       ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();

			Console.SetCursorPosition(17, 8);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ ((Convert.ToDouble(load.NoChange.Goats) * 100.0) / Convert.ToDouble(load.NoChange.Goats + load.NoChange.Cars + additional1)).ToString("0.00") }%       ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();

			Console.SetCursorPosition(17, 9);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door1.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Total");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door1Hits.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Cars");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door1Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Goats");
			Console.WriteLine();

			Console.SetCursorPosition(17, 10);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door2.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Total");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door2Hits.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Cars");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door2Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Goats");
			Console.WriteLine();

			Console.SetCursorPosition(17, 11);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door3.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Total");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door3Hits.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Cars");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.NoChange.Door3Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Goats");
			Console.WriteLine();


			Console.SetCursorPosition(17, 15);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Cars.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ ((Convert.ToDouble(load.Change.Cars) * 100.0) / Convert.ToDouble(load.Change.Goats + load.Change.Cars + additional2)).ToString("0.00") }%       ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();

			Console.SetCursorPosition(17, 16);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ ((Convert.ToDouble(load.Change.Goats) * 100.0) / Convert.ToDouble(load.Change.Goats + load.Change.Cars + additional2)).ToString("0.00") }%       ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();

			Console.SetCursorPosition(17, 17);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door1.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Total");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door1Hits.ToString("n", this.UICultureInfo).Replace(",00", "")}");			
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Cars");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door1Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Goats");
			Console.WriteLine();

			Console.SetCursorPosition(17, 18);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door2.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Total");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door2Hits.ToString("n", this.UICultureInfo).Replace(",00", "")}");			
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Cars");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door2Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Goats");
			Console.WriteLine();

			Console.SetCursorPosition(17, 19);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door3.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Total");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door3Hits.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Cars");
			Console.Write(" | ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{ load.Change.Door3Goats.ToString("n", this.UICultureInfo).Replace(",00", "")}");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" Goats");
			Console.WriteLine();

			//
			// Render Elapsed Time
			//
			Console.SetCursorPosition(17, 3);
			Console.ForegroundColor = this.NumberColor;
			Console.Write($"{(DateTime.Now - dtStarted)}");
		}	
				
		/// <summary>
		/// Renders result (who wins).
		/// </summary>
		/// <param name="run1Result"></param>
		/// <param name="run2Result"></param>
		internal void RenderResult(double run1Result, double run2Result)
		{
			Console.SetCursorPosition(17, 21);
			if (run1Result == run2Result)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("Draw");
			}
			else if (run1Result > run2Result)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("No Change");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Change");
			}

			Console.SetCursorPosition(0, 25);

			Console.ForegroundColor = ConsoleColor.White;

			Console.WriteLine();
		}
	}// class
}// namespace
