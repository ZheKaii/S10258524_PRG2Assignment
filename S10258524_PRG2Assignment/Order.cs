using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

//==========================================
// Student Number : S10258441
// Student Name : Gan Yu Hong
// Partner Name : Heng Zhe Kai
//==========================================

namespace S10258524_PRG2Assignment
{
    internal class Order
    {
        private int id;
        private DateTime timeReceived;
        private DateTime? timeFulfilled;
        private List<IceCream> iceCreamsList;
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; } = new List<IceCream>();

        public Order() { }
        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
        }
        public void ModifyIceCream(int index)
        {
            IceCream selectedIceCream= IceCreamList[index - 1];

            Console.WriteLine("[1] Option");
            Console.WriteLine("[2] Scoops");
            Console.WriteLine("[3] Flavours");
            Console.WriteLine("[4] Toppings");
            Console.Write("Enter option to modify: ");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Console.Write("Enter option (cone, cup, waffle): ");
                selectedIceCream.Option = Console.ReadLine().ToLower();
                if (selectedIceCream is Cone cone && selectedIceCream.Option == "cone")
                {
                    Console.Write("Do you want the cone to be dipped? (y/n)");
                    string dip = Console.ReadLine();
                    if (dip == "Y" || dip == "y")
                    {
                        cone.Dipped = true;
                    }
                    else if (dip == "N" || dip == "n")
                    {
                        cone.Dipped = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                else if (selectedIceCream is Waffle waffle && selectedIceCream.Option == "waffle")
                {
                    Console.Write("What flavour would you like (Original, Pandan, Charcoal, Red Velvet): ");
                    waffle.WaffleFlavour = Console.ReadLine().ToLower();
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (option == 2) 
            {
                Console.WriteLine("Enter number of scoops (1-3)");
                int scoops = int.Parse(Console.ReadLine());
                for (int i = 0; i < scoops; i++)
                {
                    Console.Write($"Would you like to have a premium flavour for scoop {i + 1}? (y/n): ");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "y")
                    {
                        Console.Write("What kind of flavour would you like (Durian, Sea Salt, Ube): ");
                        string flavourchosen = Console.ReadLine().ToLower();
                        if (flavourchosen == "durian" || flavourchosen == "sea salt" || flavourchosen == "ube")
                        {
                            Flavour flavour = new Flavour(flavourchosen, true);
                            selectedIceCream.Flavours.Add(flavour);
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid premium flavour.");
                            i--;
                        }
                    }
                    else if (choice == "n")
                    {
                        Console.Write("\nWhat normal flavour would you like (Vanilla, Strawberry, Chocolate): ");
                        string flavourchosen = Console.ReadLine().ToLower();
                        if (flavourchosen == "vanilla" || flavourchosen == "strawberry" || flavourchosen == "chocolate")
                        {
                            Flavour flavour = new Flavour(flavourchosen, false);
                            selectedIceCream.Flavours.Add(flavour);
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter a valid normal flavour.");
                            i--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter a valid input (y/n): ");
                        i--;
                    }
                }
            }
            else if (option == 3) 
            {
                
            }
            else if (option == 4)
            {

            }
            else { Console.WriteLine("Invalid input."); }
        }
        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }
        public void DeleteIceCream(int index)
        {
            if (index < IceCreamList.Count && index >= 0)
            {
                IceCreamList.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        public double CalculateTotal()
        {
            double total = 0;
            for (int i = 0; i < IceCreamList.Count; i++)
            {
                total += IceCreamList[i].CalculatePrice();
            }
            return total;
        }
        public override string ToString()
        {
            if (TimeFulfilled == null)
            {
                return $"id: {Id}, timeRecieved: {TimeReceived}, timeFulfilled: - ";
            }
            else
            {
                return $"id: {Id}, timeRecieved: {TimeReceived}, timeFulfilled: {TimeFulfilled}";
            }
        }
    }
}
