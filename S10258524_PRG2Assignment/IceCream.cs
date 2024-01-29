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
    abstract class IceCream
    {
        private string option;
        private int scoops;
        private List<Flavour> flavours;
        private List<Topping> toppings;
        public string Option { get; set; }
        public int Scoops { get; set; }
        public List<Flavour> Flavours { get; set; } = new List<Flavour>();
        public List<Topping> Toppings { get; set; } = new List<Topping>();
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
            return $"Option: {Option}, Scoops: {Scoops}, Flavours: {string.Join(", ", Flavours.Select(flavor => flavor.Type))}, Toppings: {string.Join(", ", Toppings.Select(topping => topping.Type))}";
        }
    }
}
