using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10258524_PRG2Assignment
{
    abstract class IceCream
    {
        public string Option { get; set; }
        public int Scoops { get; set; }
        public List<Flavour> Flavours { get; set; }
        public List<Topping> Toppings { get; set; }
        public IceCream() { }
        public IceCream(string options, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = options;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
        }
        public abstract double CalculatePrice();
        public override string ToString()
        {
            return "Option: " + Option + "\tScoops: " + Scoops + "\tFlavours: " + Flavours + "\tToppings: " + Toppings;
        }
    }
}
