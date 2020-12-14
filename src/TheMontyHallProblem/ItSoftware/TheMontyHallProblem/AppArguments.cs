using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItSoftware.TheMontyHallProblem
{
	/// <summary>
	/// Application parameters class.
	/// </summary>
	internal class AppArguments
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="args"></param>
		internal AppArguments(string[] args)
		{
			foreach (var arg in args)
			{
				if (arg == "?" || arg == "/?")
				{
					throw new ArgumentException();
				}
				else if (arg.ToLower().IndexOf("samplesize:") != -1)
				{
					string[] split = arg.Split(':');
					if (split.Length == 2)
					{
						long val = -1;
						if (!long.TryParse(split[1].Replace("_",""), out val))
						{
							continue;
						}
						if (val <= 0)
						{
							continue;
						}
						this.SampleSize = val;
					}
				}
				else if (arg.ToLower().IndexOf("logfilenochange:") != -1)
				{
					string[] split = arg.Split(':');
					if (split.Length >= 2)
					{
						var fname = new StringBuilder();
						for (int i = 1; i < split.Length; i++)
						{
							if (i > 1)
							{
								fname.Append(":");
							}
							fname.Append(split[i]);
						}
						this.LogFileNoChange = fname.ToString();
					}
				}
				else if (arg.ToLower().IndexOf("logfilechange:") != -1)
				{
					string[] split = arg.Split(':');
					if (split.Length >= 2)
					{
						var fname = new StringBuilder();
						for ( int i = 1; i < split.Length; i++)
						{
							if ( i > 1 )
							{
								fname.Append(":");
							}
							fname.Append(split[i]);
						}
						this.LogFileChange = fname.ToString();
					}
				}
			}
		}

		/// <summary>
		/// SampleSize parameter property. Defaults to 100.
		/// </summary>
		internal long SampleSize { get; set; } = 100;
		internal string LogFileNoChange { get; set; } = null;
		internal string LogFileChange { get; set; } = null;
	}
}
