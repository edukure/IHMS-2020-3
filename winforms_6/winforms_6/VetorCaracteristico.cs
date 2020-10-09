using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winforms_6
{
    public class VetorCaracteristico
    {
        public double MAV { get; set; }
        public double AutoCorrAbs { get; set; }
        public double StdAbs { get; set; }
        public VetorCaracteristico(double mav, double autoCorrAbs, double stdAbs)
        {
            MAV = mav;
            AutoCorrAbs = autoCorrAbs;
            StdAbs = stdAbs;
        }

        public VetorCaracteristico(double[] window)
        {
            MAV = Utilities.MeanAbsoluteValue(window);
            AutoCorrAbs = Utilities.AutoCorrAbs(window, 2);
            StdAbs = Utilities.StdAbs(window);
        }


    }
}
