using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_1_v3
{
    public class Steel
    {
        public double Ore { get; set; }
        public double Nickel { get; set; }
        public double Chrom { get; set; }
        public double Manganese { get; set; }
        public double TimeFurnaces { get; set; }
        public double TimeConverter { get; set; }
        public double Mill { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public Steel(List<double> extractedNumbers)
        {
            Ore = extractedNumbers[0];
            Nickel = extractedNumbers[1];
            Chrom = extractedNumbers[2];
            Manganese = extractedNumbers[3];
            TimeFurnaces = extractedNumbers[4];
            TimeConverter = extractedNumbers[5];
            Mill = extractedNumbers[6];
            Price = extractedNumbers[7];
            Volume = extractedNumbers[8];

            extractedNumbers.RemoveRange(0, 9);
        }
    }
}
