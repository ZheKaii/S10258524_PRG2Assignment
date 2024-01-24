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
        }

        //Basic Feature 2 - Gan Yu Hong
        static void Main2(string[] args)
        {
            string[] all_line = File.ReadAllLines("orders.csv");
            string[] headers = all_line[0].Split(",");
            Console.WriteLine("{0,2}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10}{7,10}{8,10}{9,10}{10,10}{11,10}{12,10}{13,10}{14,10}{15,10}",
                headers[0], headers[1], headers[2], headers[3], headers[4], headers[5], headers[6], headers[7],
                headers[8], headers[9], headers[10], headers[11], headers[12], headers[13], headers[14], headers[15]);
        }

        //Basic Feature 3 - Heng Zhe Kai

    }
}