using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloNEtCore
{
    public static class TaxCalculator
    {
        public static (float totalTax,float totalPer, float netAmount) 
            CalculateTax((float amount, bool isGovtEmployee) data)
                   
        {
            float taxPer = 0.0F;

            if (!data.isGovtEmployee)
            {
                if (data.amount > 200000)
                {
                    taxPer = 0.05F;
                }
                else
                {
                    taxPer = 0.10F;
                }

                
            }

            float totalTax = data.amount * taxPer;
            float netTax = data.amount + totalTax;

            return (totalTax,taxPer,netTax);
        }
    
        public static (float totalTax, float totalPer, float netAmount) 
                    CalcualteSalaray((float amount,float baseSalary) sal)
            {
                 return (0, 0, 0);
            }
        
    }
}
