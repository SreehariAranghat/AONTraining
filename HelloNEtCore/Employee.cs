using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestNameSpace
{
    file static class CTCCalculator
    {
        public static decimal CalculateCTC(decimal baseSal)
        {
            return baseSal + 10000;
        }
    }
}

namespace HelloNEtCore
{

    file static class Avathar
    {
        public static string Generate(string seed)
        {
            return "test";
        }
    }

    public class Employee
    {
        public readonly int Id;
        public required string Name { get; set; }
        public string Email { get; set; }

        /*[SetsRequiredMembers]
        public Employee(string name)
        {
            Name = name;
        }*/

        public decimal CTC
        {
            get
            {
                return TestNameSpace.CTCCalculator.CalculateCTC(1000);
            }
        }

    }
}
