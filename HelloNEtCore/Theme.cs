using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloNEtCore
{
    public class Theme
    {
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string BgColor { get; set; }

        public string Logo { get; set; }

        public override string ToString()
        {
            return $"{Name} / {PrimaryColor} " +
                $"/ {BgColor} / {Logo}";
        }
    }
}
