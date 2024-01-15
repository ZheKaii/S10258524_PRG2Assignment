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
            // Basic Feature 2
            string[] all_line = File.ReadAllLines("orders.csv");
            string[] headers = all_line[0].Split(",");
            Console.WriteLine("{0,-3} {1,-9} {2,-13} {3,-15} {4,-7} {5,-7} {6,-7} {7,-15} {8,-9} {9,-9} {10,-9} {11,-9} {12,-9} {13,-9} {14,-9}",
                headers[0], headers[1], headers[2], headers[3], headers[4], headers[5], headers[6], headers[7], headers[8], headers[9], headers[10], 
                headers[11], headers[12], headers[13], headers[14]);
            List<Order> orders = new List<Order>();
            for (int i = 1; i < all_line.Length; i++)
            {
                string[] cols = all_line[i].Split(",");
                string id = cols[0];
                string memberid = cols[1];
                DateTime timereceived = Convert.ToDateTime(cols[2]);
                DateTime timefulfilled = Convert.ToDateTime(cols[3]);
                string option = cols[4];
                int scoops = Convert.ToInt32(cols[5]);
                string dipped = cols[6];
                string waffleFlavour = cols[7];
                string flavour1 = cols[8];
                string flavour2 = cols[9];
                string flavour3 = cols[10];
                string topping1 = cols[11];
                string topping2 = cols[12];
                string topping3 = cols[13];
                string topping4 = cols[14];
            }
        }
    }
}