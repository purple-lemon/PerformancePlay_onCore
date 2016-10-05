using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PerformancePlay
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var dbW = new DbWorker();
			long sum = 0;
			for (var i = 0; i < 50; i++)
			{
				var sw = Stopwatch.StartNew();
				var z = dbW.GetResumes();
				sw.Stop();
				Console.WriteLine($"Iteration: {i}, Time: {sw.ElapsedMilliseconds}");
				if (i > 0)
				{
					sum += sw.ElapsedMilliseconds;
				}
			}
			Console.WriteLine($"Total: {sum / 49}");
			Console.ReadLine();
		}
    }
}
