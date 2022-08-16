using System;
using System.IO;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var arrUsers = new Users[]
        {
            new Users("Tupac","Shakur"),
            new Users("Tom","Petty"),
            new Users("O'Shea","Jackson")
        };

        // Main Menu Loop
        bool successfull = false;
        bool loggedIn = false;
        string username = "";
        while (!successfull)
        {
            // Main Menu Displayed
            // ---------------------------------------------------------------------------------
            if (loggedIn)
            {
                // If the user is logged in display their user name in the menu
                Console.WriteLine("\n Bits and Bytes Autobody Shop\t\tEmployee: " + username + "\n          Main Menu\n ----------------------------\n\n 1) Register\n 2) Login\n 3) Purchase\n 0) Exit\n\n");
            }
            else
            {
                // Do not display user name in menu as the use has not logged in
                Console.WriteLine("\n Bits and Bytes Autobody Shop\t\tNOT LOGGED IN\n          Main Menu\n ----------------------------\n\n 1) Register\n 2) Login\n 3) Purchase\n 0) Exit\n\n");
            }
            Console.Write(" Please choose: ");
            var input = Console.ReadLine();

            // Register New Bits and Bytes Employee
            if (input == "1")
            {
                Console.Write("\n Enter your username: ");
                username = Console.ReadLine();

                Console.Write(" Enter your password: ");
                var password = Console.ReadLine();

                Array.Resize(ref arrUsers, arrUsers.Length + 1);
                arrUsers[arrUsers.Length - 1] = new Users(username, password);
            }

            // Login Bits and Bytes Employee
            else if (input == "2")
            {
                Console.Write("\n Write your username: ");
                username = Console.ReadLine();
                Console.Write(" Enter your password: ");
                var password = Console.ReadLine();

                foreach (Users user in arrUsers)
                {
                    if (username == user.username && password == user.password)
                    {
                        Console.WriteLine(" You have successfully logged in !!!");
                        loggedIn = true;
                        break;
                    }
                }

                if (!loggedIn)
                {
                    Console.WriteLine(" Your username or password is incorect, try again !!!");
                }

            }

            // Enter new sales (Purchases)
            else if (input == "3")
            {
                // Must be logged in to perform a purchase
                if (!loggedIn)
                {
                    Console.WriteLine(" You must login to perform purchases.");
                } else
                {
                    // Purchase Menu / System
                    // ---------------------------------------------------------------------------------
                    Console.WriteLine("\n Bits and Bytes Autobody Shop\t\tEmployee: " + username + "\n        Purchase Menu\n ----------------------------\n");

                    Console.Write(" Enter customer phone number: ");
                    var phonenumber = Console.ReadLine();

                    // Lookup phone number in Customer table
                    // Connect to the database, if it does not exist create it along with any seed data
                    using (DatabaseContext context = new DatabaseContext())
                    {
                        // Loop through every record in the Customer table...
                        foreach (Customer customer in context.Customers.ToList())
                        {
                            Console.WriteLine(customer.NameFirst + " " + customer.NameLast + " " + customer.PhoneNumber);
                            // Test if the current customer.PhoneNumber = the phone number the user entered (in variable phonenumber)
                            // if customer.phonenumber = phonenumber then
                            // {
                            // you found the matching customer,
                            // set a flag,
                            // break
                            // }
                        }
                        // test flag if true {found customer do stuff}
                        // else{no matching customer found enter new cuystomer or new phone number}
                    }
                    // Moved DatabaseContext to the Models namespace
                    // Made corrections to the Main Menu loop
                    // Ensured user had to login to purchase
                    // Read the customer database and match on phone number (check is customer exists)

                }
            }

            // Exit Bits and Byyes Sales System
            else if (input == "0")
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
