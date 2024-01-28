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
        }

        public Order MakeOrder(IceCream iceCream)
        {
            Order newcustomerorder = new Order();
            while (true)
            {
                Console.WriteLine("Ice Cream type 1, 2 and 3: Cup, Cone, Waffle");
                Console.Write("Please choose a type of ice cream (enter the number): ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1 && option == 2 && option == 3)
                {
                    if (option == 1)
                    {
                        Cup cup = new Cup();
                        cup.Option = "cup";
                        cup.Flavours = new List<Flavour>();
                        cup.Toppings = new List<Topping>();
                        Order order = new Order();
                        CurrentOrder = order;
                        while (true)
                        {
                            Console.Write("Enter number of scoops (1, 2, 3): ");
                            int numberofscoops = Convert.ToInt32(Console.ReadLine());
                            if (numberofscoops == 1 && numberofscoops == 2 && numberofscoops == 3)
                            {
                                iceCream.Scoops = numberofscoops;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid number (1, 2, 3).");
                            }
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number (1, 2, 3).");
                }
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
