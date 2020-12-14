using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// namespace.
/// </summary>
namespace ItSoftware.TheMontyHallProblem
{
	/// <summary>
	/// Statistics class for stats of Goats and Cars.
	/// </summary>
	internal class Statistics
	{
		/// <summary>
		/// Cars property.
		/// </summary>
		internal long Cars { get; set; } = 0;
		/// <summary>
		/// Goats property.
		/// </summary>
		internal long Goats { get; set; } = 0;
		/// <summary>
		/// Door1 count.
		/// </summary>
		internal long Door1 { get; set; } = 0;
		internal long Door1Hits { get; set; } = 0;
		internal long Door1Goats { get; set; } = 0;
		/// <summary>
		/// Door2 Count.
		/// </summary>
		internal long Door2 { get; set; } = 0;
		internal long Door2Hits { get; set; } = 0;
		internal long Door2Goats { get; set; } = 0;
		/// <summary>
		/// Door3 count.
		/// </summary>
		internal long Door3 { get; set; } = 0;
		internal long Door3Hits { get; set; } = 0;
		internal long Door3Goats { get; set; } = 0;

		/// <summary>
		/// Add stats from another Stats class.
		/// </summary>
		/// <param name="stats"></param>
		internal void Add(Statistics stats)
		{
			this.Cars += stats.Cars;
			this.Goats += stats.Goats;
			this.Door1 += stats.Door1;
			this.Door1Hits += stats.Door1Hits;
			this.Door1Goats += stats.Door1Goats;
			this.Door2 += stats.Door2;
			this.Door2Hits += stats.Door2Hits;
			this.Door2Goats += stats.Door2Goats;
			this.Door3 += stats.Door3;
			this.Door3Hits += stats.Door3Hits;
			this.Door3Goats += stats.Door3Goats;
		}
	}// class
}// namespace
