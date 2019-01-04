using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
/// namespace.
/// </summary>
namespace ItSoftware.TheMontyHallProblem
{
	/// <summary>
	/// Simulation WorkParameter class.
	/// </summary>
	internal class WorkLoad : IDisposable
	{
		/// <summary>
		/// NoChange Stats class object property.
		/// </summary>
		internal Statistics NoChange { get; set; } = new Statistics();
		/// <summary>
		/// Change Stats class object property.
		/// </summary>
		internal Statistics Change { get; set; } = new Statistics();
		/// <summary>
		/// SampleSize property.
		/// </summary>
		internal long SampleSize { get; set; }
		internal FileLogger LogNoChange { get; set; }
		internal FileLogger LogChange { get; set; }

		public void Dispose()
		{
			if ( this.LogNoChange != null )
			{
				this.LogNoChange.Dispose();
			}

			if (this.LogChange != null)
			{
				this.LogChange.Dispose();
			}
		}
	}// class
}// namespace
