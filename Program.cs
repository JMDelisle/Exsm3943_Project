using System;
using System.IO;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Main Menu Loop
        bool successfull = false;
        string username = "";
        string adminName = "ADMIN";
        string adminPassword = "PASSWORD";
    Start:
        while (!successfull)
        {
            Console.Clear();
            // Main Menu Displayed
            Console.WriteLine("\n Bits and Bytes Autobody Shop\t\tNOT LOGGED IN\n\t\t\tMain Menu\n\t\t\n\n\n\t\t1) Log In\n\t\t2) Admin Menu\n\t\t3) Exit\n");
            Console.Write(" Please choose: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Write("\n Enter your account Phone Number ");
                string userNumber = Console.ReadLine(); // don't use var
                // querry on database for the customers table on the phone number column
                using (DatabaseContext context = new DatabaseContext())
                {
                    // Loop through every phone number in the Customer table...
                    foreach (Customer customer in context.Customers.ToList())
                  {
                       Console.WriteLine(customer.NameFirst + " " + customer.NameLast + " " + customer.PhoneNumber); // testing only

                        // Console.WriteLine(userNumber); testing only
                        // Console.WriteLine(customer.PhoneNumber); testing only

                        // Test if the current customer.PhoneNumber = the phone number the user entered (in variable phonenumber)
                        
                    if (userNumber != customer.PhoneNumber)

                        {
                            Console.WriteLine("\n\tPhone Number not found, Would you Like to add it to the system?");
                            var answer = Console.ReadLine();

                            if (answer != "Y")
                            {
                                goto Start;
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\tWelcome Back " + customer.NameFirst + "!\n What Product Category are you lookiing for today?");
                                foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                                {
                                    Console.WriteLine(productCategory.Id + " " + productCategory.CategoryName);

                                    // if category 1
                                    // {
                                    // display all products from category 1
                                    Console.WriteLine("What product would you like to buy?");
                                    var purcahseItem = Console.ReadLine();
                                    // }

                                    // if category 2
                                    // {
                                    // display all products from category 2
                                    // }

                                    // if category 3
                                    // {
                                    // display all products from category 3
                                    // }

                                    // if category 4
                                    // {
                                    // display all products from category 4
                                    // }

                                    // if category 5
                                    // {
                                    // display all products from category 5
                                    // }

                                    // if category 6
                                    // {
                                    // display all products from category 6
                                    // }


                                }
                            }
                        }
                        // Login Bits and Bytes Admin
                        if (input == "2")
                        {
                        AdminName:
                            Console.Clear();
                            Console.Write("\n Enter the Admin User Name: ");
                            username = Console.ReadLine();
                            if (username != adminName)
                            {
                                Console.WriteLine("Incorrect.  Try again");
                                goto AdminName;
                            }
                            else
                            {
                            Password:
                                Console.Clear();
                                Console.Write("\n\nEnter the Admin password: ");
                                var userPassword = Console.ReadLine();
                                if (userPassword != adminPassword)
                                {
                                    Console.WriteLine("Incorrect.  Try again");
                                    goto Password;
                                }
                                else
                                {//all admin menu code below this 
                                 //here we need to build and code the admin menu

                                    /*menu needs to have 
                                    1)Add Stock
                                    2)Remove Stock        
                                    3)Flag product as discontinued
                                    0)Exit
                                    */
                                    int adminSelection = -1;
                                    while (adminSelection != 3)
                                    {


                                        Console.Clear();
                                        Console.WriteLine("\n\n\t\t\tBits & Bytes Admin Menu\n\n\t\t1) Add Stock to Inventory\n\t\t2) Remove Stock from Inventory\n\t\t3) Flag Stock as DISCONTINUED\n\t\t0) Log Out of ADMIN MENU\n\n\t\t\tPlease make your selection: ");
                                        try
                                        {
                                            adminSelection = Int32.Parse((Console.ReadLine() ?? "").Trim());








                                        }
                                        catch
                                        {
                                            break;
                                        }

                                    }
                                }//all admin menu code above this
                            }
                            // Exit Bits and Byyes Sales System
                            if (input == "3")
                            {
                                Console.WriteLine("\n\n\tGoodbye " + username + "\n");
                                successfull = true;
                            }
                            // Invalid entry by user :(
                            else
                            {
                                Console.WriteLine("\n * * * Invalid Menu Selection, Try again * * *\n\tPress any key to continue");
                                Console.ReadKey();
                                goto Start;
                            }
                        }
                    }
                }
            }
        }
    }

    public class Users
    {
        public string username;
        public string password;

        public Users(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
