using System;
using System.IO;
using System.Linq;

namespace TempDiff
{
    class Program
    {
        
        private static readonly string _filePath1 = "..//..//..//weatherdata.csv";
        private static readonly string _filePath2 = "..//..//..//TempData.csv";
        private static readonly int padding = 5; /*make padding = 10 for _filePath2*/
        static void Main(string[] args)
        {
            Console.WriteLine("Reading weather data from provided file. . . \n ");
            var dataRows = File.ReadLines(_filePath1).Select(a => a.Split(','));

            int count = dataRows.Count();
            var listData = dataRows.ToList();
            int minTempDifference = 999;
            int tempDifference = 0;
            string dayOfWeek = "None";
            string minTempVariationDay = "None";
            int minTemp = 0;
            int maxTemp = 1;

            foreach (var column in listData[0])
            {
                Console.Write(column.PadRight(padding) + "\t");
            }

            for (int i = 1; i < count; i++)
            {
                var row = listData[i];

                Console.WriteLine();
                foreach (var column in row)
                {
                    Console.Write(column.PadRight(padding) + "\t");
                }

                if (i < count - 1)
                {
                    dayOfWeek = row[0];
                    minTemp = Convert.ToInt32(row[2]);
                    maxTemp = Convert.ToInt32(row[1]);
                    tempDifference = maxTemp - minTemp;

                    if (tempDifference < minTempDifference)
                    {
                        minTempDifference = tempDifference;
                        minTempVariationDay = dayOfWeek;
                    }
                }
            }

            Console.WriteLine("\n\nThe Day with the lowest variation in temperature is day : " + minTempVariationDay + " with the temperature variation of " + minTempDifference + " degrees");
            Console.ReadKey();
        }
    }
}
