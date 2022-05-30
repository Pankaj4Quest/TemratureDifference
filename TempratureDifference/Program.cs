using System;
using System.IO;
using System.Linq;

namespace TempDiff
{
    class Program
    {
        private static readonly string _filePath = "..//..//..//TempData.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Reading temprature data from provided data in file. . . \n ");
            var dataRows = File.ReadLines(_filePath).Select(a => a.Split(','));

            int count = dataRows.Count();
            var listData = dataRows.ToList();
            int minTempDifference = 999;
            int tempDifference = 0;
            string dayOfWeek = "None";
            string minTempVariationDay = "None";
            int minTemp = 0;
            int maxTemp = 1;

            Console.WriteLine("Day oF Week" + "\t" + "Min Temp" + "\t" + "Max Temp");
            for (int i = 1; i < count; i++)
            {
                var row = listData[i];
                dayOfWeek = row[0];
                minTemp = Convert.ToInt32(row[1]);
                maxTemp = Convert.ToInt32(row[2]);
                tempDifference = maxTemp - minTemp;

                if (tempDifference < minTempDifference)
                {
                    minTempDifference = tempDifference;
                    minTempVariationDay = dayOfWeek;
                }


                Console.WriteLine(dayOfWeek.PadRight(10) + "\t" + minTemp + "\t\t" + maxTemp);
            }

            Console.WriteLine("\n\nDay with minimum temprature variation is : " + minTempVariationDay + " with temprature variation of " + minTempDifference + " degrees");
            Console.ReadKey();
        }
    }
}
