using System;
using System.IO;
using System.Collections.Generic;

//==========================================
// Student Number : S10258524
// Student Name : Heng Zhe Kai
// Partner Name : Gan Yu Hong
//==========================================

namespace S10258524_PRG2Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Basic Feature 1 - Heng Zhe Kai
            string[] all_line = File.ReadAllLines("customers.csv");
            string[] headers = all_line[0].Split(",");
            Console.WriteLine("{0,-11}{1,-10}{2,-23}{3,-18}{4,-18}{5,-11}",
                headers[0], headers[1], headers[2], headers[3], headers[4], headers[5]);

            List<Customer> customers = new List<Customer>();
            for (int i = 1; i < all_line.Length; i++)
            {
                string[] cols = all_line[i].Split(",");
                string name = cols[0];
                int memberid = int.Parse(cols[1]);
                DateTime dob = DateTime.ParseExact(cols[2], "dd/MM/yyyy", null);
                string membershipstatus = cols[3];
                int membershippoints = int.Parse(cols[4]);
                int punchcard = int.Parse(cols[5]);
                PointCard pointCard = new PointCard(membershippoints, punchcard, membershipstatus);
                Customer customer = new Customer(name, memberid, dob);
                customer.Rewards = pointCard;
                customers.Add(customer);
            }
            for (int i = 0; i < customers.Count; i++)
            {
                Customer c = customers[i];
                Console.WriteLine("{0,-11}{1,-10}{2,-23}{3,-18}{4,-18}{5,-11}", c.Name, c.MemberId, c.Dob, c.Rewards.Tier, c.Rewards.Points, c.Rewards.PunchCards);
            }
            Console.WriteLine();

            // Basic Feature 3 - Heng Zhe Kai
            Console.Write("Enter your name: ");
            string customername = Console.ReadLine();
            Console.Write("Enter your ID number: ");
            int customerid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your date of birth: ");
            DateTime customerdob = Convert.ToDateTime(Console.ReadLine());
            Customer c1 = new Customer(customername, customerid, customerdob);
            PointCard p1 = new PointCard(0, 0, "Ordinary");
            c1.Rewards = p1;
            using (StreamWriter sw = new StreamWriter("customers.csv", true))
            {
                sw.WriteLine($"{c1.Name},{c1.MemberId},{c1.Dob},{c1.Rewards.Tier},{c1.Rewards.Points},{c1.Rewards.PunchCards}");
            }
            Console.WriteLine("You have successfully registered as a membership in our system!");
            Console.WriteLine();

            // Basic Feature 4 - Heng Zhe Kai
            for (int i = 0; i < customers.Count;i++)
            {
                Customer c = customers[i];
                Console.WriteLine("{0,-11}{1,-10}{2,-23}{3,-18}{4,-18}{5,-11}", c.Name, c.MemberId, c.Dob, c.Rewards.Tier, c.Rewards.Points, c.Rewards.PunchCards);
            }
            Customer? Search(List<Customer> customerslist, string orderingcustomer)
            {
                foreach(Customer customer in customerslist)
                {
                    if (customer.Name == orderingcustomer)
                    {
                        return customer;
                    }
                }
                return null;
            }
            Console.WriteLine("Please select a customer from the list: ");
            string orderingcustomer = Console.ReadLine();
            Customer foundcustomername = Search(customers, orderingcustomer);
            if (foundcustomername == null)
            {
                Console.WriteLine("Unable to find the customer name. Please try again.");
            }
            else
            {
                Console.Write("Enter your ice cream option: ");
                string option = Console.ReadLine();
                Console.WriteLine("Enter the number of scoops: ");
                int scoops = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your flavour(s): ");
                string type = Console.ReadLine();
                List<Flavour> flavours = new List<Flavour>();
                Console.WriteLine("Enter your topping(s): ");
                string topping = Console.ReadLine();
                List<Topping> toppings = new List<Topping>();
            }

            // For Yu Hong to do his features
            Main2(args);
        }

        //Basic Feature 2 - Gan Yu Hong
        static void Main2(string[] args)
        {
            string[] all_line = File.ReadAllLines("orders.csv");
            string[] headers = all_line[0].Split(",");
            Console.WriteLine("{0,-2} {1,-8} {2,-22} {3,-22} {4,-6} {5,-6} {6,-6} {7,-14} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10} {13,-10} {14,-10}",
                headers[0], headers[1], headers[2], headers[3], headers[4], headers[5], headers[6], headers[7],
                headers[8], headers[9], headers[10], headers[11], headers[12], headers[13], headers[14]);
            List<Order> orders = new List<Order>();
            for (int i = 1;  i < all_line.Length; i++)
            {
                string[] cols = all_line[i].Split(",");
                int id = int.Parse(cols[0]);
                int memberid = int.Parse(cols[1]);
                DateTime timeReceived = DateTime.ParseExact(cols[2], "dd/MM/yyyy HH:mm", null);
                DateTime? timefulfilled = DateTime.ParseExact(cols[3], "dd/MM/yyyy HH:mm", null);
                string option = cols[4];
                int scoops = int.Parse(cols[5]);
                string dipped = cols[6];
                string waffleflavour = cols[7];
                string flavour1 = cols[8];
                string flavour2 = cols[9];
                string flavour3 = cols[10];
                string topping1 = cols[11];
                string topping2 = cols[12];
                string topping3 = cols[13];
                string topping4 = cols[14];
                Console.WriteLine("{0,-2} {1,-8} {2,-22} {3,-22} {4,-6} {5,-6} {6,-6} {7,-14} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10} {13,-10} {14,-10}",
                id, memberid, timeReceived, timefulfilled, option, scoops , dipped, waffleflavour, flavour1, flavour2, flavour3, topping1, topping2, topping3, topping4);
            }
        }
    }
}