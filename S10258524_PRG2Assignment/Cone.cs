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
                    totalprice += (premiumflavourprice * f.Quantity);
                }
            }
            int toppingsprice = 1;
            totalprice += (toppingsprice * Toppings.Count);
            int chocolateconeprice = 2;
            totalprice += chocolateconeprice;
            return totalprice;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
