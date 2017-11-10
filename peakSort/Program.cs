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
            //ピークとして認識される最小値
            double threshold = -79.0d;
            // 80Mの倍数からのずれの許容値
            long tolerance = 255000;
            int type = 2;
            try {
                Dictionary<string, double> data = new Dictionary<string, double>();
                using (StreamReader r = new StreamReader(args[0]))
                {
                    string line;
                    int index = 0;
                    while ((line = r.ReadLine()) != null)
                    {
                        string[] res = line.Split(',');
                        //double val = double.Parse(res[1]);
                        if(type == 1)
                        {
                            double val = double.Parse(res[1]);
                            long freq = long.Parse(res[0]);
                            if (val > threshold)
                            {
                                data.Add(res[0], val);
                            }
                        }
                        else if (type == 2)
                        {
                            double val = double.Parse(res[0]);
                            long freq = long.Parse(res[1]);

                            /*if (val > threshold && Math.Abs(freq - (80000000L * index)) < tolerance)
                            {
                                data.Add(res[1], val);
                            }
                            if(Math.Abs(freq - (80000000L * index)) < tolerance)
                            {
                                index++;
                            }*/

                            
                            // Alternative method.
                            if (Math.Abs(freq - (80000000L * index)) < tolerance)
                            {
                                data.Add(res[1], val);
                                Console.WriteLine(freq);
                                index++;
                            }
                        }
                    }
                }

                using (StreamWriter w = new StreamWriter("peak_" + args[0]))
                {
                    foreach (KeyValuePair<string, double> elem in data)
                    {
                        w.WriteLine(elem.Key + "," + elem.Value);
                    }
                }

                /*int row = 0;
                double v = 0;
                using (StreamWriter w = new StreamWriter("diff_" + args[0]))
                {
                    w.WriteLine("freq/80Mhz, dB");
                    foreach (KeyValuePair<string, double> elem in data)
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

                }*/
            } catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Check Usage");
                return;
            }
        }
    }
}
