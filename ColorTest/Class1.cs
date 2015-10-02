using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorTest
{
    class Class1
    {
        public string model { get; set; }
        public int hue { get; set; }
        public int check { get; set; }

        public Class1(string x, int y, int z)
        {
            this.model = x;
            this.check = z;
            this.hue = y;
        }

    }
}
