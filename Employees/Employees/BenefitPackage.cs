using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class BenefitPackage
    {
        // nested object
        private enum BenefitPackageLevel
        {
            Standard,
            Gold,
            Platinum
        }
        // assume other members here
        public double ComputePayDeduction()
        {
            return 125.0;
        }
    }
}
