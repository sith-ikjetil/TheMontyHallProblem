using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ItSoftware.TheMontyHallProblem
{
	internal class FileLogger : IDisposable
	{	
		internal string FileName { get; set; }
		internal StreamWriter Writer { get; set; }
		internal FileLogger(string filename)
		{
			this.FileName = filename;
			File.Delete(filename);
			this.Writer = File.AppendText(this.FileName);
		}

		private bool doWrite = true;
		internal void WriteTo(string text)
		{			
			if (this.Writer != null && doWrite)
			{
				try
				{
					this.Writer.Write($"{text}{Environment.NewLine}{Environment.NewLine}");
				}
				catch ( Exception )
				{					
					doWrite = false;					
				}
			}
		}

		public void Dispose()
		{
			if ( this.Writer != null )
			{
				this.Writer.Flush();
				this.Writer.Dispose();
				this.Writer = null;
			}
		}
	}
}
