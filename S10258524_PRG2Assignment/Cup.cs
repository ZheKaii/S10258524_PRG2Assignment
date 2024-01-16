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
    internal class Cup : IceCream
    {
        public Cup() : base() { }
        public Cup(string options, int scoops, List<Flavour> flavours, List<Topping> toppings) : base("Cup", scoops, flavours, toppings)
        {
        
        }
        public override double CalculatePrice()
        {
            double price = 0;
            string scoops = "";
            if (scoops == "Single")
            {
                price = 4.00;
            }
            else if (scoops == "Double")
            {
                price = 5.50;
            }
            else if (scoops == "Triple")
            {
                price = 6.50;
            }
            return price;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
