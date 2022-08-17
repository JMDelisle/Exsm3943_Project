using System;
using System.IO;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Need to add an admin password and log in

        // Main Menu Loop
        bool successfull = false;
        string username = "";
        string adminName = "ADMIN";
        string adminPassword = "PASSWORD";
    Start:
        while (!successfull)
        {
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
                            Console.WriteLine("Phone Number not found, Would you Like to add it to the system?");
                            var answer = Console.ReadLine();

                            if (answer != "Y")
                            {
                                goto Start;
                            }


                        else
                        {
                            Console.WriteLine("Welcome Back " + customer.NameFirst +"!\n What Product Category are you lookiing for today?");
                            foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                            {
                                Console.WriteLine(productCategory.Id + " " + productCategory.CategoryName);
                            }
                        }
                        }
                        // test flag if true {found customer do stuff}
                        // else{no matching customer found enter new cuystomer or new phone number}
                    }
                    // Login Bits and Bytes Admin
                   //
                    if (input == "2")
                    {
                    AdminName:
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
                            Console.Write(" Enter the Admin password: ");
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
                                5)Flag product as discontinued
                                0)Exit
                                */


                            }//all admin menu code above this
                        }
                        // Exit Bits and Byyes Sales System
                        if (input == "3")
                        {
                            Console.WriteLine("\n Goodbye " + username + "\n");
                            successfull = true;
                        }
                        // Invalid entry by user :(
                        else
                        {
                            Console.WriteLine("\n * * * Invalid Menu Selection, Try again * * *\n");
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
