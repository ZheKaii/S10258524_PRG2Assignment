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
            // Basic Feature 1
            string[] all_line = File.ReadAllLines("customers.csv");
            string[] headers = all_line[0].Split(",");
            Console.WriteLine("{0,-6}{1,-10}{2,-5}{3,-18}{4,-18}{5,-11}",
                headers[0], headers[1], headers[2], headers[3], headers[4], headers[5]);
        }
    }
}