using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll
{
    public class dll
    {
        public static double SaleCost(int countBook, double Cost)
        {
            double sale = 0;

            if (countBook >= 3)
            {
                sale = 0.05;
            }
            if (countBook >= 5)
            {
                sale = 0.10;
            }
            if (countBook >= 10)
            {
                sale = 0.15;
            }
            if (Cost / 500 >= 1)
            {
                double d = Convert.ToDouble(Math.Floor((Cost / 500)) / 100);
                sale = sale + d;
            }
            return sale;
        }
    }
}
