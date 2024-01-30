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
            Console.WriteLine(selectedIceCream);
            Console.WriteLine("[1] Option");
            Console.WriteLine("[2] Scoops and Flavour");
            Console.WriteLine("[3] Toppings");
            int option;
            while(true)
            {
                try
                {
                    Console.Write("\nWhat would you like to modify: ");
                    option = int.Parse(Console.ReadLine());
                    if (option >=1 && option <=3)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter number from 1-3.");
                    continue;
                }
            }
            if (option == 1)
            {
                Console.Write("\nEnter new option (cup, cone, waffle): ");
                string opt = Console.ReadLine().ToLower();
                Console.WriteLine("\nSelected Ice cream: "+ selectedIceCream);
                if (opt == "cup")
                {
                    Cup cup = new Cup("Cup", selectedIceCream.Scoops, selectedIceCream.Flavours, selectedIceCream.Toppings);
                    IceCreamList[index - 1] = cup;
                    Console.WriteLine("\nUpdated Ice cream: " + IceCreamList[index - 1]);

                }
                else if (opt == "cone" )
                {
                    bool dipcone;
                    while (true)
                    {
                        Console.Write("\nDo you want the cone to be dipped? (y/n): ");
                        string dippedcone = Console.ReadLine();
                        
                        if (dippedcone.ToLower() == "y")
                        {
                            dipcone = true;
                            break;
                        }
                        else if (dippedcone.ToLower() == "n")
                        {
                            dipcone = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input");
                        }
                    }
                    Cone cone= new Cone("cone", selectedIceCream.Scoops, selectedIceCream.Flavours, selectedIceCream.Toppings, dipcone);
                    IceCreamList[index - 1] = cone;
                    Console.WriteLine("\nUpdated Ice cream: " + IceCreamList[index - 1]);
                }

                else if (opt == "waffle")
                {
                    string newFlavour;
                    while (true)
                    {                    
                        Console.Write("Enter new waffle flavour(Original, Pandan, Charcoal, Red Velvet): ");
                        newFlavour = Console.ReadLine();
                        if (newFlavour.ToLower() == "original" || newFlavour.ToLower() == "pandan" ||
                            newFlavour.ToLower() == "charcoal" || newFlavour.ToLower() == "red velvet")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        
                    }
                    Waffle waffle = new Waffle("waffle", selectedIceCream.Scoops, selectedIceCream.Flavours, selectedIceCream.Toppings,newFlavour);
                    IceCreamList[index - 1] = waffle;
                    Console.WriteLine("\nUpdated Ice cream: " + IceCreamList[index - 1]);
                }
                else
                {
                    Console.WriteLine("Please enter the following option (cup, cone, waffle)");
                }
                
            }
            else if (option == 2) 
            {
                selectedIceCream.Flavours.Clear();
                int scoops;
                while (true)
                {
                    try
                    {
                        Console.Write("Enter number of scoops (1-3): ");
                        scoops = int.Parse(Console.ReadLine());
                        if (scoops >= 1 && scoops <= 3)
                        {
                            break;
                        }
                        
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    
                }      
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
                Console.WriteLine("\nUpdated Ice cream: " + IceCreamList[index - 1]);
            }
            else if (option == 3) 
            {
                selectedIceCream.Toppings.Clear();
                int top;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter number of toppings (0-4): ");
                        top = int.Parse(Console.ReadLine());
                        if (top >= 0 && top <= 4)
                        {
                            break;
                        }

                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                }
                for (int i = 0; i < top; i++)
                {
                    Console.Write($"What topping would you like for topping {i + 1}? (Oreo, Mochi, Sprinkles, Sago): ");
                    string toppingchosen = Console.ReadLine().ToLower();
                    Topping topping;
                    if (toppingchosen == "oreo" || toppingchosen == "mochi" || toppingchosen == "sprinkles" || toppingchosen == "sago")
                    {
                        topping = new Topping(toppingchosen);
                        selectedIceCream.Toppings.Add(topping);
                        Console.WriteLine($"Topping {i + 1}: {toppingchosen}");
                    }
                    else
                    {
                        Console.WriteLine("\nPlease choose a valid topping.");
                        i--;
                    }
                }
            }    
            else { Console.WriteLine("Please enter option 1-3."); }
            
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
