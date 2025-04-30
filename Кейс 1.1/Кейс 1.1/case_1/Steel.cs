using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_1
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
        public Steel(List<double> resourcess)
        {
            Ore = resourcess[0];
            Nickel = resourcess[1];
            Chrom = resourcess[2];
            Manganese = resourcess[3];
            TimeFurnaces = resourcess[4];
            TimeConverter = resourcess[5];
            Mill = resourcess[6];
            Price = resourcess[7];
            Volume = resourcess[8];

            resourcess.RemoveRange(0, 9);
        }
    }
}
