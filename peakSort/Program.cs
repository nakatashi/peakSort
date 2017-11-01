using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peakSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int argCount = args.Length;
            Dictionary<string, double> data = new Dictionary<string, double>();
            if(argCount == 1)
            {
                using (StreamReader r = new StreamReader(args[0]))
                {
                    string line;
                    while((line = r.ReadLine()) != null)
                    {
                        string[] res = line.Split(',');
                        double val = double.Parse(res[1]);
                        if(val > -65.0d)
                        {
                            data.Add(res[0], val);
                        }
                    }
                }

                using (StreamWriter w = new StreamWriter("peak_" + args[0]))
                {
                    foreach(KeyValuePair<string, double> elem in data)
                    {
                        w.WriteLine(elem.Key + ","+ elem.Value);
                    }
                }

                int row = 0;
                double v = 0;
                using (StreamWriter w = new StreamWriter("diff_" + args[0]))
                {
                    w.WriteLine("freq/80Mhz, dB");
                    foreach(KeyValuePair<string, double> elem in data)
                    {
                        if (row % 2 == 1)
                        {
                            w.WriteLine(row + "," + (v - elem.Value));
                        }
                        else
                        {
                            v = elem.Value;
                        }
                        row++;
                    }
                   
                }
            }
        }
    }
}
