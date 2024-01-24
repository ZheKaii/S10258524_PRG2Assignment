using System;

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
            for (int i = 0; i <customers.Count; i++)
            {
                Customer c = customers[i];
                Console.WriteLine("{0,-11}{1,-10}{2,-23}{3,-18}{4,-18}{5,-11}", c.Name, c.MemberId, c.Dob, c.Rewards.Tier, c.Rewards.Points, c.Rewards.PunchCards);
            }

            //Basic Feature 2 - Gan Yu Hong
            static void main(string[] arg)
            {
                string[] all_line = File.ReadAllLines("option.csv");
                string[] headers = all_line[0].Split(",");
            }

            //Basic Feature 3 - Heng Zhe Kai
        }
    }
}