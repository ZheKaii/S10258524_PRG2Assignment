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
    internal class Cup : IceCream
    {
        public Cup() : base() { }
        public Cup(string options, int scoops, List<Flavour> flavours, List<Topping> toppings) : base("Cup", scoops, flavours, toppings)
        {
        
        }
        public override double CalculatePrice()
        {
            double totalprice = 0.00;
            double normalprice = 4.00;
            double twiceprice = 5.50;
            double tripleprice = 6.50;
            if (Scoops == 1)
            {
                totalprice += normalprice;
            }
            else if (Scoops == 2)
            {
                totalprice += twiceprice;
            }
            else if (Scoops == 3)
            {
                totalprice += tripleprice;
            }
            double premiumflavourprice = 2.00;
            foreach (Flavour f in Flavours)
            {
                if (f.Premium)
                {
                    totalprice += premiumflavourprice;
                }
            }
            int toppingsprice = 1;
            totalprice += (toppingsprice * Toppings.Count);
            return totalprice;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
