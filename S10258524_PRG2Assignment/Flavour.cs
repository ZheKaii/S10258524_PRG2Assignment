using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================
// Student Number : S10258441
// Student Name : Gan Yu Hong
// Partner Name : Heng Zhe Kai
//==========================================

namespace S10258524_PRG2Assignment
{
    internal class Flavour
    {
        private string type;
        private bool premium;

        public string Type { get; set; }
        public bool Premium { get; set; }

        public Flavour() { }
        
        public Flavour(string type, bool premium)
        {
            Type = type;
            Premium = premium;
        }
        public override string ToString()
        {
            return Type;
        }
    }
}
