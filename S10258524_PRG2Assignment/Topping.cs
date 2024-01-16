using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================
// Student Number : S10258524
// Student Name : Heng Zhe Kai
// Partner Name : Gan Yu Hong
//==========================================

namespace S10258524_PRG2Assignment
{
    internal class Topping
    {
        private string type;
        public string Type { get; set; }
        public Topping() { }
        public Topping(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return "Type of Topping(s): " + Type;
        }
    }
}
