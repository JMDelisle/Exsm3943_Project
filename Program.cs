using System;
using System.IO;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //Main Menu Looping
        bool successfull = false;
        string username = "";
        string adminName = "ADMIN";
        string adminPassword = "PASSWORD";

        Start:
        while (!successfull)
        {
            Console.Clear();

            //Displayed Menu
            Console.WriteLine("\t\t\t\t\tBits and Bytes Autobody Shop \n\n\t\t\t\t\t\tNOT LOGGED IN \n\n\t\t\t\t\t\t Main Menu \t\n 1) Login \t\n 2) Admin Menu \t\n 3) Exit ");
            Console.Write("Please choose: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("\n Enter your account phone number: ");
                string userNumber = Console.ReadLine();
                // Querry on database for the customers table on the phone number column
                using (DatabaseContext context = new DatabaseContext())
                {
                    foreach (Customer customer in context.Customers.ToList())
                    {
                       // context.Customers.Where(x => x.PhoneNumber == customer).Single().RecieveStock();            // to call a Single customer not a whole list.
                        context.SaveChanges();
                       // Console.WriteLine(customer.NameFirst + " " + customer.NameLast + " " + customer.PhoneNumber);

                        //To test if the current customer.PhoneNumber = the phone number the user entered (in variable PhoneNumber)
                        if (userNumber != customer.PhoneNumber)
                        {
                            Console.WriteLine("Phone number not found, Would you like to add it to the system? ");
                            string answer = Console.ReadLine();

                            if (answer != "Y")
                            {
                                goto Start; // If yes to add new customer, prompt customer information firstname, lastname, phonenumber, address
                            }
                            else if (answer != "N")
                            {
                                goto Start;
                            }
                            else
                            {
                                Console.WriteLine("Welcome Back " + customer.NameFirst + "!\n What product category are you looking for today?"); // After this line should display all product category
                                foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                                {
                                    Console.WriteLine(productCategory.Id + " " + productCategory.CategoryName);
                                }
                            }
                            // 

                        }
                    }
                }         
            }
            if (input == "2")
            {
            AdminName:
                Console.WriteLine("\n Enter your Admin User Name: ");
                username = Console.ReadLine();
                if (username != adminName)
                {
                    Console.WriteLine("Incorrect. Try Again!");
                    goto AdminName;
                }
                else
                {
                Password:
                    Console.WriteLine("\n Enter your Admin Password: ");
                    var userPassword = Console.ReadLine();
                    if(userPassword != adminPassword)
                    {
                        Console.WriteLine("Incorrect. Try Again!");
                        goto Password;
                    }
                    else
                    {
                        // Add Stock
                        // Remove Stock
                        // Flag product as discontinued
                        // 0) Exit
                        int adminSelection = -1;
                        while (adminSelection != 3)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\t\t\tBits & Bytes Admin Menu\n\n\t\t1) Add Stock to Inventory\n\t\t2) Remove Stock from Inventory\n\t\t3) Flag Stock as DISCONTINUED\n\t\t0) Log Out of ADMIN MENU\n\n\t\t\tPlease make your selection: ");
                        }
                        try
                        {
                            adminSelection = Int32.Parse((Console.ReadLine()?? " ").Trim());
                        }
                        catch
                        {
                            break;
                        }
                    }// all admin codes above this
                }
            }
            if (input == "3")
            {
                Console.WriteLine("\n Goodbye " + username + "\n");
                successfull = true;
            }
            else // Invalid entry point by user
            {
                Console.WriteLine("\n * * * Invalid Menu Selection, Try Again * * *\n");
                Console.ReadKey();
                goto Start;
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