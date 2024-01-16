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
    internal class Cone : IceCream
    {
        private bool dipped;
        public bool Dipped { get; set; }
        public Cone() : base() { }
        public Cone(string options, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped) : base("Cone", scoops, flavours, toppings)
        {
            Dipped = dipped;
        }
        public override double CalculatePrice()
        {
            double price = 0;
            return price;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
