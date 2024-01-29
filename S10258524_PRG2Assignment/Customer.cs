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
    internal class Customer
    {
        private string name;
        private int memberid;
        private DateTime dob;
        private Order currentOrder;
        private List<Order> ordersHistory;
        private PointCard rewards;
        public string Name { get; set; }
        public int MemberId { get; set; }
        public DateTime Dob { get; set; }
        public Order CurrentOrder { get; set; }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public PointCard Rewards { get; set; }
        public Customer() { }
        public Customer(string name, int memberId, DateTime dob)
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
            Rewards = new PointCard();
            CurrentOrder = new Order();
        }

        public void MakeOrder()
        {
            Order newcustomerorder = new Order();
            while (true)
            {
                Console.WriteLine("Ice Cream type 1, 2 and 3: Cup, Cone, Waffle");
                Console.Write("Please choose a type of ice cream (enter the number): ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Cup cup = new Cup();
                    cup.Option = "cup";
                    cup.Flavours = new List<Flavour>();
                    cup.Toppings = new List<Topping>();
                    OrderIceCream(cup);
                    CurrentOrder.IceCreamList.Add(cup);
                    newcustomerorder.AddIceCream(cup);
                    CurrentOrder.TimeReceived = DateTime.Now;
                    break;
                }
                else if (option == 2)
                {
                    Cone cone = new Cone();
                    cone.Flavours = new List<Flavour>();
                    cone.Toppings = new List<Topping>();
                    cone.Option = "cone";
                    OrderIceCream(cone);
                    Console.Write("Do you want the cone to be dipped? (y/n): ");
                    string dippedcone = Console.ReadLine();
                    if (dippedcone.ToLower() == "y")
                    {
                        cone.Dipped = true;
                    }
                    else if (dippedcone.ToLower() == "n")
                    {
                        cone.Dipped = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option (y/n).");
                    }
                    CurrentOrder.IceCreamList.Add(cone);
                    newcustomerorder.AddIceCream(cone);
                    CurrentOrder.TimeReceived = DateTime.Now;
                    break;
                }
                else if (option == 3)
                {
                    Waffle waffle = new Waffle();
                    waffle.Option = "waffle";
                    waffle.Flavours = new List<Flavour>();
                    waffle.Toppings = new List<Topping>();
                    OrderIceCream(waffle);
                    Console.Write("Do you want a flavoured waffle (y/n): ");
                    string waffleflavour = Console.ReadLine();
                    if (waffleflavour.ToLower() == "y")
                    {
                        Console.Write("What flavour would you like (Pandan, Charcoal, Red Velvet): ");
                        string wafflechoice = Console.ReadLine().ToLower();
                        if (wafflechoice == "red velvet" || wafflechoice == "charcoal" || wafflechoice == "pandan")
                        {
                            waffle.WaffleFlavour = wafflechoice;
                            CurrentOrder.IceCreamList.Add(waffle);
                            newcustomerorder.AddIceCream(waffle);
                            CurrentOrder.TimeReceived = DateTime.Now;
                            break;
                        }
                    }
                    else if (waffleflavour.ToLower() == "n")
                    {
                        CurrentOrder.IceCreamList.Add(waffle);
                        newcustomerorder.AddIceCream(waffle);
                        CurrentOrder.TimeReceived = DateTime.Now;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid choice (y/n).");
                    }
                    break;
                } 
                else
                {
                    Console.WriteLine("Please enter a valid number (1, 2, 3).");
                }
            }
        }
        public void OrderIceCream(IceCream iceCream)
        {
            Order order = new Order();
            CurrentOrder = order;
            int scoops;
            while (true)
            {
                Console.Write("Enter number of scoops (1, 2, 3): ");
                int numberofscoops = Convert.ToInt32(Console.ReadLine());
                if (numberofscoops > 0 && numberofscoops < 4)
                {
                    scoops = numberofscoops;
                    iceCream.Scoops = numberofscoops;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number (1, 2, 3).");
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
                        iceCream.Flavours.Add(flavour);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid premium flavour.");
                        i--;
                    }
                }
                else if (choice == "n")
                {
                    Console.Write("What normal flavour would you like (Vanilla, Strawberry, Chocolate): ");
                    string flavourchosen = Console.ReadLine().ToLower();
                    if (flavourchosen == "vanilla" || flavourchosen == "strawberry" || flavourchosen == "chocolate")
                    {
                        Flavour flavour = new Flavour(flavourchosen, false);
                        iceCream.Flavours.Add(flavour);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid normal flavour.");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid input (y/n): ");
                    i--;
                }
            }
            Console.Write("Would you like to have any toppings (y/n): ");
            string choice2 = Console.ReadLine().ToLower();
            if (choice2 == "y")
            {
                int toppings;
                while (true)
                {
                    Console.Write("Enter the number of toppings you want: ");
                    int numberoftoppings = Convert.ToInt32(Console.ReadLine());
                    if (numberoftoppings > 0 && numberoftoppings < 5)
                    {
                        toppings = numberoftoppings;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer (1, 2, 3, 4): ");
                    }
                }
                for (int i = 0; i < toppings; i++)
                {
                    Console.Write($"What topping would you like for topping {i + 1}? (Oreo, Mochi, Sprinkles, Sago): ");
                    string toppingchosen = Console.ReadLine().ToLower();
                    Topping topping;
                    if (toppingchosen == "oreo" || toppingchosen == "mochi" || toppingchosen == "sprinkles" || toppingchosen == "sago")
                    {
                        topping = new Topping(toppingchosen);
                        iceCream.Toppings.Add(topping);
                        Console.WriteLine($"Topping {i + 1}: {toppingchosen}");
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid topping.");
                        i--;
                    }
                }
            }
            else if (choice2 == "n")
            {
                Console.WriteLine("No toppings added for you.");
            }
            else
            {
                Console.WriteLine("Please enter a valid choice (y/n): ");
            }
        }
        public bool IsBirthday()
        {
            DateTime dateTime = DateTime.Today;
            if (dateTime == Dob)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return Name + MemberId + Dob + Rewards;
        }
    }
}
