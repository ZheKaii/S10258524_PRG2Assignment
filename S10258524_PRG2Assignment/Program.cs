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
        
        //Basic Feature 3 - Heng Zhe Kai

    }
}