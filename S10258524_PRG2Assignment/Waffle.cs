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
    internal class Waffle : IceCream
    {
        private string waffleFlavour;
        public string WaffleFlavour { get; set; }
        public Waffle() : base() { }
        public Waffle(string options, int scoops, List<Flavour> flavours, List<Topping> toppings, string waffleFlavour) : base("Waffle", scoops, flavours, toppings)
        {
            WaffleFlavour = waffleFlavour;
        }
        public override double CalculatePrice()
        {
            double totalprice = 0.00;
            double normalprice = 7.00;
            double twiceprice = 8.50;
            double tripleprice = 9.50;
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
            if (waffleFlavour == null)
            {
                return $"Option: {Option} | Scoops: {Scoops} | Flavours: {string.Join(", ", Flavours.Select(flavor => flavor.Type))} | Toppings: {string.Join(", ", Toppings.Select(topping => topping.Type))} | Waffle flavour: Original";

            }
            return $"Option: {Option} | Scoops: {Scoops} | Flavours: {string.Join(", ", Flavours.Select(flavor => flavor.Type))} | Toppings: {string.Join(", ", Toppings.Select(topping => topping.Type))} | Waffle flavour: {WaffleFlavour}";
        }
    }
}
