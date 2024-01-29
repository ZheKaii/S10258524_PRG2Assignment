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
            // Making a menu for the program

            int DisplayMenu()
            {
                Console.WriteLine("\n---------------- M E N U --------------------");
                Console.WriteLine("[1] List information of all the customers");
                Console.WriteLine("[2] List information of all current orders");
                Console.WriteLine("[3] Register a new customer");
                Console.WriteLine("[4] Create a customer's order");
                Console.WriteLine("[5] Display order details of a customer");
                Console.WriteLine("[6] Modify order details");
                Console.WriteLine("[7] Process order and checkout");
                Console.WriteLine("[8] Display monthly and total charge");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Enter your option: ");
                int option = int.Parse(Console.ReadLine());
                return option;
            }

            // All our lists
            List<Customer> customers = new List<Customer>();
            List<Order> orders = new List<Order>();
            Queue<Order> ordersQueue = new Queue<Order>();
            Queue<Order> goldenordersQueue = new Queue<Order>();

            // Making a method to be used for option 1 and 4

            void Readingcustomerscsv()
            {
                // Reading the customers.csv file

                string[] all_line = File.ReadAllLines("customers.csv");

                // Assigning each column to a variable except for the headers and adding them to the customers list

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

            // Activating the method
            Readingcustomerscsv();

            // Basic Feature 1 - Heng Zhe Kai

            void Option1(List<Customer> customers)
            {
                Console.WriteLine("Name       MemberId  DOB           MembershipStatus  MembershipPoints  PunchCard");
                for (int i = 0; i < customers.Count; i++)
                {
                    Customer c = customers[i];
                    Console.WriteLine($"{c.Name,-11}{c.MemberId,-10}{c.Dob:dd/MM/yyyy}    {c.Rewards.Tier,-18}{c.Rewards.Points,-18}{c.Rewards.PunchCards,-11}");
                }
                Console.WriteLine();
            }

            // Method to check if the customer wants premium flavour for option 2

            bool checkPremium(string flavour)
            {
                if (flavour == "Durian" || flavour == "Ube" || flavour ==" Sea Salt")
                {
                    
                    return true;
                }
                return false;
            }

            // Basic Feature 2 - Gan Yu Hong

            void Option2()
            {
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

            // Basic Feature 3 - Heng Zhe Kai

            void Option3()
            {
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

            // Making a search method to search for the customer

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

            // Basic Feature 4 - Heng Zhe Kai

            void Option4(List<Customer> customers, Queue<Order> goldenordersQueue, Queue<Order> ordersQueue)
            {
                // Making use of option 1 to print out the customers information

                Option1(customers);
                Console.Write("Please select a customer from the list: ");
                string orderingcustomer = Console.ReadLine();
                Customer foundcustomername = Search(customers, orderingcustomer);
                if (foundcustomername == null)
                {
                    Console.WriteLine("Unable to find the customer name. Please try again.");
                }
                else
                {
                    foreach (Customer customer in customers)
                    {
                        if (customer.Name == orderingcustomer)
                        {
                            Console.WriteLine($"The customer you selected is: {customer.Name}, {customer.MemberId}");
                            customer.MakeOrder();
                            if (customer.Rewards.Tier == "Gold")
                            {
                                goldenordersQueue.Enqueue(customer.CurrentOrder);
                                Console.WriteLine("You made a successful order in the gold queue!!");
                            }
                            else
                            {
                                ordersQueue.Enqueue(customer.CurrentOrder);
                                Console.WriteLine("You made a successful order in the normal queue!!");
                            }
                        }
                    }
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

            // Basic Feature 6 - Gan Yu Hong

            void Option6()
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine(orders[i]);
                   
                }
            }

            // Advanced Feature (a) - Heng Zhe Kai

            void Option7(List<Customer> customers, Queue<Order> goldenordersQueue, Queue<Order> ordersQueue)
            {
                Order customerOrder;
                Customer payingcustomer = new Customer();
                if (ordersQueue.Count != 0)
                {
                    customerOrder = ordersQueue.Dequeue();
                }
                else
                {
                    customerOrder = goldenordersQueue.Dequeue();
                }
                Console.Write("May I double check your name? : ");
                string orderingcustomer = Console.ReadLine();
                Customer foundcustomername = Search(customers, orderingcustomer);
                payingcustomer = foundcustomername;
                if (foundcustomername == null)
                {
                    Console.WriteLine("Unable to find the customer name. Please try again.");
                }
                else
                {
                    PointCard pointCard = new PointCard(foundcustomername.Rewards.Points, foundcustomername.Rewards.PunchCards, foundcustomername.Rewards.Tier);
                    payingcustomer.Rewards = pointCard;
                    foreach (IceCream iceCream in customerOrder.IceCreamList)
                    {
                        Console.WriteLine(iceCream.ToString());
                    }
                    double totalpayingprice = customerOrder.CalculateTotal();
                    Console.WriteLine($"Total: {totalpayingprice:F2}");
                    Console.WriteLine("Your membership status: ", payingcustomer.Rewards.Tier);
                    bool checkexpIcecream = true;
                    if (payingcustomer.IsBirthday() == true)
                    {
                        IceCream mostexpIcecream = customerOrder.IceCreamList[0];
                        for (int i = 1; i < customerOrder.IceCreamList.Count; i++)
                        {
                            if (customerOrder.IceCreamList[i].CalculatePrice() > mostexpIcecream.CalculatePrice())
                            {
                                mostexpIcecream = customerOrder.IceCreamList[i];
                                checkexpIcecream = false;
                            }
                        }
                        totalpayingprice -= mostexpIcecream.CalculatePrice();
                    }
                    if (pointCard.PunchCards == 10)
                    {
                        if (checkexpIcecream = true)
                        {
                            totalpayingprice -= customerOrder.IceCreamList[1].CalculatePrice();
                        }
                        else
                        {
                            totalpayingprice -= customerOrder.IceCreamList[0].CalculatePrice();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < customerOrder.IceCreamList.Count; i++)
                        {
                            pointCard.Punch();
                        }
                    }
                    if (pointCard.Tier.ToLower() == "silver" || pointCard.Tier.ToLower() == "gold")
                    {
                        int redeempoints;
                        while (true)
                        {
                            Console.Write("How many points would you like to redeem (0 to exit): ");
                            int reductionpoints = Convert.ToInt32(Console.ReadLine());
                            redeempoints = reductionpoints;
                            if (reductionpoints == 0)
                            {
                                break;
                            }
                            else if (reductionpoints > pointCard.Points)
                            {
                                Console.WriteLine("You do not have enough points to redeem.");
                                continue;
                            }
                            else if (reductionpoints < 0)
                            {
                                Console.WriteLine("Please enter a positive integer.");
                                continue;
                            }
                            pointCard.RedeemPoints(redeempoints);
                            totalpayingprice -= (redeempoints * 0.02);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your membership status is Ordinary. You cannot redeem points yet.");
                    }
                    Console.WriteLine($"Total: {totalpayingprice:F2}");
                    Console.Write("Press anything to process the checkout: ");
                    Console.ReadLine();
                    pointCard.AddPoints((int)totalpayingprice);
                    customerOrder.TimeFulfilled = DateTime.Now;
                    payingcustomer.OrderHistory.Add(customerOrder);
                }
            }

            // Making a loop for the menu and options until the user enters 0 to end the program

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
                    Option4(customers, goldenordersQueue, ordersQueue);
                }
                else if (option == 5)
                {
                    Option5();
                }
                else if (option == 6)
                {
                    Option6();
                }
                else if (option == 7)
                {
                    Option7(customers, goldenordersQueue, ordersQueue);
                }
                else
                {
                    Console.WriteLine("Please choose another option.");
                }
            }
        }
    }
}