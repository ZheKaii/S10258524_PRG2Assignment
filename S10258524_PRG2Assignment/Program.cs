using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Pipes;

//==========================================
// Student Number : S10258441
// Student Name : Gan Yu Hong
// Partner Name : Heng Zhe Kai
//==========================================

namespace S10258524_PRG2Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int DisplayMenu()
            {
                Console.WriteLine("\n---------------- M E N U --------------------");
                Console.WriteLine("[1] List information of all the customers");
                Console.WriteLine("[2] List information of all current orders");
                Console.WriteLine("[3] Register a new customer");
                Console.WriteLine("[4] Create a customer's order");
                Console.WriteLine("[5] Display order details of a customer");
                Console.WriteLine("[6] Modify order details");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Enter your option: ");
                int option = int.Parse(Console.ReadLine());
                return option;
            }

            List<Customer> customers = new List<Customer>();

            void Readingcustomerscsv()
            {
                string[] all_line = File.ReadAllLines("customers.csv");
                string[] headers = all_line[0].Split(",");

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
            }

            Readingcustomerscsv();

            void Option1(List<Customer> customers)
            {
                // Basic Feature 1 - Heng Zhe Kai
                Console.WriteLine("Name       MemberId  DOB           MembershipStatus  MembershipPoints  PunchCard");
                for (int i = 0; i < customers.Count; i++)
                {
                    Customer c = customers[i];
                    Console.WriteLine($"{c.Name,-11}{c.MemberId,-10}{c.Dob:dd/MM/yyyy}    {c.Rewards.Tier,-18}{c.Rewards.Points,-18}{c.Rewards.PunchCards,-11}");
                }
                Console.WriteLine();
            }

            bool checkPremium(string flavour)
            {
                if (flavour == "Durian" || flavour == "Ube" || flavour ==" Sea Salt")
                {
                    
                    return true;
                }
                return false;
            }


            List<Order> orders = new List<Order>();
            void Option2()
            {
                // Basic Feature 2 - Gan Yu Hong
                string[] all_line = File.ReadAllLines("orders.csv");
                string[] headers = all_line[0].Split(",");
                Console.WriteLine("{0,-2} {1,-8} {2,-22} {3,-22} {4,-6} {5,-6} {6,-6} {7,-14} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10} {13,-10} {14,-10}",
                    headers[0], headers[1], headers[2], headers[3], headers[4], headers[5], headers[6], headers[7],
                    headers[8], headers[9], headers[10], headers[11], headers[12], headers[13], headers[14]);
                for (int i = 1; i < all_line.Length; i++)
                {
                    string[] cols = all_line[i].Split(",");
                    int id = int.Parse(cols[0]);
                    int memberid = int.Parse(cols[1]);
                    DateTime timeReceived = DateTime.ParseExact(cols[2], "dd/MM/yyyy HH:mm", null);
                    DateTime? timefulfilled = DateTime.ParseExact(cols[3], "dd/MM/yyyy HH:mm", null);
                    string option = cols[4];
                    int scoops = int.Parse(cols[5]);
                    bool dipped = bool.TryParse(cols[6],out dipped);
                    string waffleflavour = cols[7];
                    string flavour1 = cols[8];
                    bool premium1 = checkPremium(flavour1);
                    Flavour f1 = new Flavour(flavour1,premium1);
                    string flavour2 = cols[9];
                    bool premium2 = checkPremium(flavour2);
                    Flavour f2 = new Flavour(flavour2,premium2);
                    string flavour3 = cols[10];
                    bool premium3 = checkPremium(flavour3);
                    Flavour f3 = new Flavour(flavour3,premium3);
                    List<Flavour> flavourlist = new List<Flavour> { f1, f2, f3 };
                    Topping topping1 = new Topping(cols[11]);
                    Topping topping2 = new Topping(cols[12]);
                    Topping topping3 = new Topping(cols[13]);
                    Topping topping4 = new Topping(cols[14]);
                    List<Topping> toppinglist = new List<Topping> { topping1,topping2,topping3,topping4 };
                    IceCream icecream = null;
                    if (option == "Cup")
                    {
                        icecream = new Cup(option, scoops, flavourlist, toppinglist);
                    }
                    else if (option == "cone")
                    {
                        icecream = new Cone(option, scoops, flavourlist, toppinglist, dipped); 
                    }
                    else
                    {
                        icecream = new Waffle(option, scoops, flavourlist, toppinglist, waffleflavour);
                    }
                    Order order = new Order(id, timeReceived);
                    orders.Add(order);
                    Console.WriteLine("{0,-2} {1,-8} {2,-22} {3,-22} {4,-6} {5,-6} {6,-6} {7,-14} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10} {13,-10} {14,-10}",
                    id, memberid, timeReceived, timefulfilled, option, scoops, dipped, waffleflavour, flavour1, flavour2, flavour3, topping1.Type, topping2.Type, topping3.Type, topping4.Type);
                }
                Console.WriteLine();
            }

            void Option3()
            {
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
            }

            void Option4(List<Customer> customers)
            {
                // Basic Feature 4 - Heng Zhe Kai
                Option1(customers);
                Customer? Search(List<Customer> customerslist, string orderingcustomer)
                {
                    foreach (Customer customer in customerslist)
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
            }
            // Basic Feature 5 - Gan Yu Hong
            void Option5()
            {
                while (true)
                {
                    try
                    {
                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine(customer.Name);
                        }
                        Customer? Search(List<Customer> customerslist, string customername)
                        {
                            foreach (Customer customer in customerslist)
                            {
                                if (customer.Name == customername)
                                {
                                    return customer;                                   
                                }
                            }
                            return null;
                        }
                        Order SearchOrder(List<Order> orderslist, Customer customer)
                        {
                            foreach (Order order in customer.OrderHistory)
                            {
                                foreach (Order order2 in orderslist)
                                {
                                    if (order.Id == order2.Id)
                                    {
                                        Console.WriteLine($"found!!!!");

                                        return order2;
                                    }
                                }
                            }
                            return null;
                        }


                        Console.Write("Please select a customer from the list: ");
                        string find = Console.ReadLine();
                        Customer foundcustomer = Search(customers, find);
                        if (foundcustomer == null)
                        {
                            Console.WriteLine("Unable to find the customer name. Please try again.");
                        }
                        else
                        {
                            int memberid = foundcustomer.MemberId;
                            Order order = SearchOrder(orders, foundcustomer);
                            if (order != null)
                            {
                                Console.WriteLine("good");
                            }
                            else 
                            { 
                                Console.WriteLine("bad"+memberid); 
                            }
                        }

                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                        throw;
                    }
                }  
            }

            void Orderlist()
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine(orders[i]);
                   
                }
            }

            while (true)
            {
                int option = DisplayMenu();
                if (option == 0)
                {
                    Console.WriteLine("\n---------");
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine("---------");
                    break;
                }
                else if (option == 1)
                {
                    Option1(customers);
                }
                else if (option == 2)
                {
                    Option2();
                }
                else if (option == 3)
                {
                    Option3();
                }
                else if (option == 4)
                {
                    Option4(customers);
                }
                else if (option == 5)
                {
                    Option5();
                }
                else if (option == 6)
                {
                    Orderlist();
                }
                else
                {
                    Console.WriteLine("Please choose another option.");
                }
            }
        }
    }
}