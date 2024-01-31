using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Collections;

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
                while (true)
                {
                    try
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
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a number from 0-8");                    
                    }
                }
            }
               
            // All our lists
            List<Customer> customers = new List<Customer>();
            List<Order> orders = new List<Order>();
            Queue<Order> ordersQueue = new Queue<Order>();
            Queue<Order> goldenordersQueue = new Queue<Order>();
            List<Order> yearList = new List<Order>();
            Dictionary<int, double> monthlyamt = new Dictionary<int, double>();

            // All our extra methods 

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

            // Activating the method for option 1 and 4 to use it

            Readingcustomerscsv();

            // Method to check if the flavour is premium

            bool checkPremium(string flavour)
            {
                if (flavour == "Durian" || flavour == "Ube" || flavour == " Sea Salt")
                {

                    return true;
                }
                return false;
            }

            // Making a method to make sure the name is valid

            bool ValidName(string name)
            {
                string pattern = @"^[a-zA-Z]+$";

                return Regex.IsMatch(name, pattern);
            }

            // Making a method to make sure the id number is 6 digit

            bool ValidNumericID(int id)
            {
                string stringid = id.ToString();

                if (stringid.Length != 6)
                {
                    return false;
                }
                return true;
            }

            // Making a method to make sure the date of birth is not later than today

            bool ValidDOB(DateTime Dob)
            {
                if (Dob >= DateTime.Today)
                {
                    return false;
                }
                return true;
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

            // Making a method to read the order.csv

            void ReadOrderFile()
            {
                string[] all_line = File.ReadAllLines("orders.csv");
                string[] headers = all_line[0].Split(",");

                for (int i = 1; i < all_line.Length; i++)
                {
                    string[] cols = all_line[i].Split(",");
                    int id = int.Parse(cols[0]);
                    int memberid = int.Parse(cols[1]);
                    DateTime timeReceived = DateTime.ParseExact(cols[2], "dd/MM/yyyy HH:mm", null);
                    DateTime? timefulfilled = DateTime.ParseExact(cols[3], "dd/MM/yyyy HH:mm", null);
                    string option = cols[4];
                    int scoops = int.Parse(cols[5]);
                    bool dipped = bool.TryParse(cols[6], out dipped);
                    string waffleflavour = cols[7];
                    string flavour1 = cols[8];
                    bool premium1 = checkPremium(flavour1);
                    Flavour f1 = new Flavour(flavour1, premium1);
                    string flavour2 = cols[9];
                    bool premium2 = checkPremium(flavour2);
                    Flavour f2 = new Flavour(flavour2, premium2);
                    string flavour3 = cols[10];
                    bool premium3 = checkPremium(flavour3);
                    Flavour f3 = new Flavour(flavour3, premium3);
                    List<Flavour> flavourlist = new List<Flavour> { f1, f2, f3 };
                    Topping topping1 = new Topping(cols[11]);
                    Topping topping2 = new Topping(cols[12]);
                    Topping topping3 = new Topping(cols[13]);
                    Topping topping4 = new Topping(cols[14]);
                    List<Topping> toppinglist = new List<Topping> { topping1, topping2, topping3, topping4 };
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
                    order.IceCreamList.Add(icecream);
                    order.TimeFulfilled = timeReceived;
                    Customer? customer = customers.Find(c => c.MemberId == memberid);
                    if (customer != null)
                    {
                        if (customer.OrderHistory == null)
                        {
                            customer.OrderHistory = new List<Order>();
                        }
                        customer.OrderHistory?.Add(order);
                    }
                    orders.Add(order);

                }
                Console.WriteLine();
            }

            // Activating the method for more than 1 options to do

            ReadOrderFile();

            // Making a method to display the collection

            void DisplayCollection<T>(IEnumerable<T> collection)
            {
                if (collection?.Any() == true)
                {
                    Console.WriteLine(string.Join(", ", collection));
                }
                else
                {
                    Console.WriteLine("");
                }
            }

            // Making a method to display the orders in the queue

            void DisplayOrder(Queue<Order> orderQueue)
            {
                if (orderQueue.Count > 0)
                {
                    Console.WriteLine();
                    foreach (var order in orderQueue)
                    {
                        Console.WriteLine(order.ToString());
                        foreach (var icecream in order.IceCreamList)
                        {
                            Console.WriteLine($"Option: {icecream.Option}\nScoops: {icecream.Scoops}");

                            // Display Premium Flavours
                            Console.Write("Premium Flavours: ");
                            DisplayCollection(icecream.Flavours.Where(flavour => flavour.Premium));
                            // Display regular Flavours
                            Console.Write("Regular Flavours: ");
                            DisplayCollection(icecream.Flavours.Where(flavour => !flavour.Premium));

                            // Display Toppings
                            Console.Write("Toppings: ");
                            DisplayCollection(icecream.Toppings);

                            // Display Dipped status for Cone
                            if (icecream is Cone cone)
                            {
                                Console.WriteLine($"Dipped: {cone.Dipped}");
                            }
                            // Display Waffle flavour
                            if (icecream is Waffle waffle)
                            {
                                Console.WriteLine($"Waffle Flavour: {waffle.WaffleFlavour}");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("NA");
                }
            }

            // Making a method to remove order from the queue

            void removeQueue(Queue<Order> queue, int index)
            {
                Queue<Order> tempQueue = new Queue<Order>();
                // Store order in a temporary queue
                for (int i = 0; i < index && queue.Count > 0; i++)
                {
                    tempQueue.Enqueue(queue.Dequeue());
                }
                if (queue.Count > 0)
                {
                    // remove the order 
                    Order removedOrder = queue.Dequeue();
                    Console.WriteLine("\nIce cream is removed.");
                }
                else
                {
                    Console.WriteLine("No Order at Index " + index+1);
                }

                // Enqueue back the orders before the target index
                while (tempQueue.Count > 0)
                {
                    queue.Enqueue(tempQueue.Dequeue());
                }
            }

            // Basic Feature 1 - Heng Zhe Kai

            void Option1(List<Customer> customers)
            {
                // Printing out the headers 

                Console.WriteLine("\nName       MemberId  DOB           MembershipStatus  MembershipPoints  PunchCard");
                
                // Printing out the information of all customers

                for (int i = 0; i < customers.Count; i++)
                {
                    Customer c = customers[i];
                    Console.WriteLine($"{c.Name,-11}{c.MemberId,-10}{c.Dob:dd/MM/yyyy}    {c.Rewards.Tier,-18}{c.Rewards.Points,-18}{c.Rewards.PunchCards,-11}");
                }

                // Adding a spacing between

                Console.WriteLine();
            }

            // Basic Feature 2 - Gan Yu Hong

            void Option2()
            {
                Console.WriteLine("Display all current orders\n");
                Console.WriteLine("Gold Member Queue: ");
                if (goldenordersQueue.Count == 0)
                {
                    Console.WriteLine("Gold member queue is empty.");
                }
                else
                {
                    // Display gold member queue
                    DisplayOrder(goldenordersQueue);
                }
                Console.WriteLine("Regular Member Queue:");
                if (ordersQueue.Count == 0)
                {
                    Console.WriteLine("Regular member queue is empty.");
                }
                else
                {

                    // Display regular member queue
                    DisplayOrder(ordersQueue);
                }
            }

            // Basic Feature 3 - Heng Zhe Kai

            void Option3()
            {
                // Enable a loop for the user in case there are exceptions to the inputs

                while (true)
                {
                    Console.Write("\nEnter your name (capitalize the first letter): ");
                    string customername = Console.ReadLine();

                    // Making sure the name is valid

                    if (ValidName(customername))
                    {
                        Console.Write("Enter your ID number: ");
                        int customerid = Convert.ToInt32(Console.ReadLine());

                        // Making sure the ID number is valid

                        if (ValidNumericID(customerid))
                        {
                            Console.Write("Enter your date of birth (dd/MM/yyyy): ");
                            DateTime customerdob = Convert.ToDateTime(Console.ReadLine());

                            // Making sure the date of birth is valid

                            if (ValidDOB(customerdob))
                            {
                                Customer c1 = new Customer(customername, customerid, customerdob);
                                PointCard p1 = new PointCard(0, 0, "Ordinary");
                                c1.Rewards = p1;

                                // Appending the new customer information into the customers.csv

                                using (StreamWriter sw = new StreamWriter("customers.csv", true))
                                {
                                    sw.WriteLine($"{c1.Name},{c1.MemberId},{c1.Dob},{c1.Rewards.Tier},{c1.Rewards.Points},{c1.Rewards.PunchCards}");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter your real date of birth.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid 6 digits ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid name.");
                    }
                    
                }
                Console.WriteLine("\nYou have successfully registered as a membership in our system!");

                // Adding a space between

                Console.WriteLine();
            }

            // Basic Feature 4 - Heng Zhe Kai

            void Option4(List<Customer> customers, Queue<Order> goldenordersQueue, Queue<Order> ordersQueue)
            {
                // Making use of option 1 to print out the customers information

                Option1(customers);

                // Enable a loop for the user in case there are exceptions to the inputs

                while (true)
                {
                    // Finding the customer that is ordering

                    Console.Write("\nPlease select a customer from the list (capitalize the first letter): ");
                    string orderingcustomer = Console.ReadLine();
                    Customer foundcustomername = Search(customers, orderingcustomer);
                    if (foundcustomername == null)
                    {
                        Console.WriteLine("\nUnable to find the customer name. Please try again.");
                        continue;
                    }
                    else
                    {
                        foreach (Customer customer in customers)
                        {
                            if (customer.Name == orderingcustomer)
                            {
                                // Printing the information of the customer chosen

                                Console.WriteLine($"The customer you selected is: {customer.Name}, {customer.MemberId}");

                                // Using the makeorder method to make an order for the customer

                                customer.MakeOrder();
                                if (customer.Rewards.Tier == "Gold")
                                {
                                    goldenordersQueue.Enqueue(customer.CurrentOrder);
                                    Console.WriteLine("\nYou made a successful order in the gold queue!!");
                                }
                                else
                                {
                                    ordersQueue.Enqueue(customer.CurrentOrder);
                                    Console.WriteLine("\nYou made a successful order in the normal queue!!");
                                }
                            }
                        }
                    }
                    break;
                }
                // Adding a space between

                Console.WriteLine();
            }

            // Basic Feature 5 - Gan Yu Hong

            void Option5()
            {
                while (true)
                {
                    // Print the customer detail
                    Option1(customers);

                    Console.Write("Please select a customer from the list (capitalize the first letter): ");
                    string find = Console.ReadLine();
                    // Search for customer and store in found customer
                    Customer foundcustomer = Search(customers, find);
                    if (foundcustomer == null)
                    {
                        Console.WriteLine("Unable to find the customer name. Please try again.");
                    }
                    else
                    {
                        if (foundcustomer.OrderHistory != null)
                        {
                            // Display past order
                            Console.WriteLine("Order Details (Past Orders):");
                            DisplayOrder(new Queue<Order>(foundcustomer.OrderHistory));
                        }
                        // Display Current order
                        Console.WriteLine("\nOrder Details (Current Orders):");
                        if (foundcustomer.CurrentOrder.IceCreamList.Any())
                        {
                            foreach (IceCream i in foundcustomer.CurrentOrder.IceCreamList)
                            {
                                Console.WriteLine(foundcustomer.CurrentOrder);
                                Console.WriteLine(i);
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("NA");
                            break;
                        }
                        
                    }

                }  
            }

            // Basic Feature 6 - Gan Yu Hong

            void Option6()
            {
                while (true)
                {
                    // Print the customer details
                    Option1(customers);
                    Console.Write("Please select a customer from the list (capitalize the first letter): ");
                    string find = Console.ReadLine();
                    // Search for customer and store in found customer
                    Customer foundcustomer = Search(customers, find);
                    if (foundcustomer == null)
                    {
                        Console.WriteLine("Customer not found. Try again.");
                        continue;
                    }
                    else
                    {
                        // Display Current order
                        Console.WriteLine("\nOrder Details (Current Orders):");
                        if (foundcustomer.CurrentOrder.IceCreamList.Any())
                        {
                            foreach (IceCream i in foundcustomer.CurrentOrder.IceCreamList)
                            {
                                Console.WriteLine(foundcustomer.CurrentOrder);
                                Console.WriteLine(i);
                            }

                            
                        }
                        else
                        {
                            Console.WriteLine("NA");
                        }
                        try
                        {
                            Console.WriteLine("\n[1]Modify an existing Ice cream.");
                            Console.WriteLine("[2]Add an entirely new Ice cream to the order.");
                            Console.WriteLine("[3]Delete an existing Ice cream from the order.");
                            Console.Write("What would you like to do: ");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                if (foundcustomer.CurrentOrder.IceCreamList.Any() == false)
                                {
                                    Console.WriteLine("No Ice Cream to modify.");
                                    break;
                                }
                                else
                                {
                                    Console.Write("\nEnter ice cream to modify: ");
                                    int id = int.Parse(Console.ReadLine());
                                    foundcustomer.CurrentOrder.ModifyIceCream(id);
                                    break;
                                }
                            }
                            else if (choice == 2)
                            {
                                foundcustomer.MakeOrder();
                                if (foundcustomer.Rewards.Tier == "Gold")
                                {
                                    goldenordersQueue.Enqueue(foundcustomer.CurrentOrder);
                                    Console.WriteLine("\nYou made a successful order in the gold queue!!");
                                    break;
                                }
                                else
                                {
                                    ordersQueue.Enqueue(foundcustomer.CurrentOrder);
                                    Console.WriteLine("\nYou made a successful order in the normal queue!!");
                                    break;
                                }
                            }
                            else if (choice == 3)
                            {
                                if (foundcustomer.CurrentOrder.IceCreamList.Any() == false)
                                {
                                    Console.WriteLine("No Ice Cream to delete.");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Enter order Index: ");
                                    int deleteindex = int.Parse(Console.ReadLine()) - 1;
                                    //foundcustomer.CurrentOrder.DeleteIceCream(deleteindex);
                                    if (foundcustomer.Rewards.Tier == "Gold")
                                    {
                                        removeQueue(goldenordersQueue, deleteindex);
                                        Console.WriteLine("\nReaming Ice cream: ");
                                        DisplayOrder(goldenordersQueue);
                                        break;

                                    }
                                    else
                                    {
                                        removeQueue(ordersQueue, deleteindex);
                                        Console.WriteLine("\nReaming Ice cream: ");
                                        DisplayOrder(ordersQueue);
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a nnumber from 1-3");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a number.");
                            
                        }
                        
                    }
                }
            }

            // Advanced Feature (a) - Heng Zhe Kai

            void Option7(List<Customer> customers, Queue<Order> goldenordersQueue, Queue<Order> ordersQueue)
            {
                Order customerOrder;
                Customer payingcustomer = new Customer();

                // Checking which queue the customer is in and dequeue

                if (ordersQueue.Count != 0)
                {
                    customerOrder = ordersQueue.Dequeue();
                }
                else
                {
                    customerOrder = goldenordersQueue.Dequeue();
                }

                // Double check their name to find their information

                Console.Write("\nMay I double check your name? (capitalize the first letter): ");
                string orderingcustomer = Console.ReadLine();
                Customer foundcustomername = Search(customers, orderingcustomer);
                if (foundcustomername == null)
                {
                    Console.WriteLine("\nUnable to find the customer name. Please try again.");
                }
                else
                {
                    PointCard pointCard = new PointCard(foundcustomername.Rewards.Points, foundcustomername.Rewards.PunchCards, foundcustomername.Rewards.Tier);
                    
                    //Printing the order of the customer

                    foreach (IceCream iceCream in customerOrder.IceCreamList)
                    {
                        Console.WriteLine(iceCream.ToString());
                    }

                    // Calculate and display the total amount to pay before discount if there is

                    double totalpayingprice = customerOrder.CalculateTotal();
                    Console.WriteLine($"\nTotal: {totalpayingprice:F2}");

                    // Display the customer's membership status 

                    if (pointCard.Tier.ToLower() == "silver")
                    {
                        Console.WriteLine("Your membership status is silver.");
                    }
                    else if (pointCard.Tier.ToLower() == "gold")
                    {
                        Console.WriteLine("Your membership status is gold.");
                    }

                    // Checking if can redeem the most expensive ice cream for their birthday

                    bool checkexpIcecream = true;

                    // Checking if it is their birthday

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

                    // Checking if they can redeem their punchcard for a free ice cream

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

                    // Allowing the customer to redeem their points if their membership status is silver or gold

                    if (pointCard.Tier.ToLower() == "silver" || pointCard.Tier.ToLower() == "gold")
                    {
                        int redeempoints;

                        //Making a loop for users to redeem their points

                        while (true)
                        {
                            Console.Write("\nHow many points would you like to redeem (0 to exit): ");
                            int reductionpoints = Convert.ToInt32(Console.ReadLine());
                            redeempoints = reductionpoints;
                            if (reductionpoints == 0)
                            {
                                break;
                            }
                            else if (reductionpoints > pointCard.Points)
                            {
                                Console.WriteLine("\nYou do not have enough points to redeem.");
                                continue;
                            }
                            else if (reductionpoints < 0)
                            {
                                Console.WriteLine("\nPlease enter a positive integer.");
                                continue;
                            }
                            pointCard.RedeemPoints(redeempoints);
                            totalpayingprice -= (redeempoints * 0.02);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYour membership status is Ordinary. You cannot redeem points yet.");
                    }

                    // Printing the total amount to pay after discount if there is any

                    Console.WriteLine($"\nTotal: {totalpayingprice:F2}");
                    Console.Write("Press anything to process the checkout: ");

                    // Ensuring the user can press anything to continue the program

                    Console.ReadLine();
                    Console.WriteLine("\nYou have successfully checkout your order!!");
                    pointCard.AddPoints((int)totalpayingprice);
                    customerOrder.TimeFulfilled = DateTime.Now;
                    payingcustomer.OrderHistory.Add(customerOrder);
                }
                // Adding a space between

                Console.WriteLine();
            }

            //Advanced feature b (Gan Yu Hong)
            void option8(List<Order> orederlist)
            {
                int year = 0;
                Console.WriteLine("\nDisplay monthly charged amounts breakdown & total charged amounts for the year.\n");
                while (true)
                {
                    try
                    {
                        
                        //prompt for year and store in var year
                        Console.Write("Enter the year: ");
                        year = int.Parse(Console.ReadLine());
                        if (year >=2000 && year <= 2100)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a year between 2000 to 2100");
                        }
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a year.");
                    }
                }

                double total = 0;

                foreach (Order order in orederlist) 
                { 
                    if (order.TimeFulfilled.Value.Year == year)
                    {
                        yearList.Add(order);
                    }
                }

                for (int key = 1; key <= 12; key++)
                {
                    // Initialize each value to 0
                    monthlyamt[key] = 0.0;
                }

                Console.WriteLine();

                foreach (Order order in yearList)
                {
                    int month = order.TimeFulfilled.Value.Month;
                    double amt = 0.0;
                    amt = order.CalculateTotal();

                    monthlyamt[month] += amt;
                    total += amt;
                }
                string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

                for (int i = 0; i < months.Length; i++)
                {
                    Console.WriteLine($"{months[i]} {year}:    ${monthlyamt[i+1]:F2}");
                }
                Console.WriteLine($"\nTotal:\t     ${total:F2}");

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
                else if (option == 8)
                {
                    option8(orders);
                }
                else
                {
                    Console.WriteLine("Option does not exist. Please choose another option.");
                }
            }
        }
    }
}