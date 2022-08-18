using System;
using System.IO;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
    Start:
        Console.Clear();
        //Declarations
        bool bInMenu = true;
        string? username;
        string? adminName = "ADMIN";
        string? adminPassword = "PASSWORD";
        bool bFoundCustomer;
        string? sCustomerName;
        int iCustomerID;
        string sCustAddress = "";
        int[] flaggedProduct;
        // MAIN MENU LOOP STARTS HERE
        while (bInMenu)
        {
            // RESET VARIABLES, IMPORTANT
            bFoundCustomer = false;
            sCustomerName = "";
            iCustomerID = 0;
            username = "";
            sCustAddress = "";

            Console.Clear();

            //Displayed Menu
            Console.WriteLine("\t\t\t\t\tBits and Bytes Autobody Shop \n\n\t\t\t\t\t\tNOT LOGGED IN \n\n\t\t\t\t\t\t Main Menu \t\n 1) Login \t\n 2) Admin Menu \t\n 3) Exit ");
            Console.Write("Please choose: ");
            string? input = Console.ReadLine();

            // Customer Login to their account
            if (input == "1")
            {

                Console.WriteLine("\n Enter your account phone number: ");
                string? sCustomerPhoneNumber = Console.ReadLine();
                // Querry on database for the customers table on the phone number column
                using (DatabaseContext context = new())
                {
                    //Debug: Sandy, 321-999-5657
                    try
                    {
                        var oCust = context.Customers.Where(customer => customer.PhoneNumber == sCustomerPhoneNumber).Single();
                        Console.WriteLine("Yes!  " + oCust.NameFirst);
                        bFoundCustomer = true;
                        sCustomerName = oCust.NameFirst + " " + oCust.NameLast;
                        iCustomerID = oCust.Id;
                        sCustAddress = oCust.Address;

                    }
                    catch
                    {
                        bFoundCustomer = false;
                    }
                }
                //To test if the current customer.PhoneNumber = the phone number the user entered (in variable PhoneNumber)
                if (!bFoundCustomer)
                {
                    Console.Write("\nPhone number not found, Would you like to add it to the system [Y/N]? ");
                    string? sAnswer = Console.ReadLine();
                    if (sAnswer == null) { sAnswer = ""; } else { sAnswer = sAnswer.Trim().ToUpper(); }
                    if (sAnswer == "Y")
                    {
                        // If yes to add new customer, prompt customer information firstname, lastname, phonenumber, address
                        Console.Write("\n Enter your First Name > ");
                        string? sNameFirst = Console.ReadLine();
                        Console.Write("\n Enter your Last Name > ");
                        string? sNameLast = Console.ReadLine();
                        Console.Write("\n Enter your Phone Number > ");
                        string? sPhoneNumber = Console.ReadLine();
                        Console.Write("\n Enter your Address > ");
                        string? sAddress = Console.ReadLine();
                        try
                        {
                            using (DatabaseContext context = new())
                            {
#pragma warning disable CS8604 // Possible null reference argument.
                                context.Customers.Add(new Customer(sNameFirst, sNameLast, sPhoneNumber, sAddress));
#pragma warning restore CS8604 // Possible null reference argument.
                                context.SaveChanges();
                            }
                            Console.WriteLine(" New Customer Added.");
                            bFoundCustomer = true;
                        }
                        catch
                        {
                            Console.WriteLine(" Customer Add FAILED.");
                            bFoundCustomer = false;
                        }
                    }
                }

                // Customer Phone Number / Account Found! 
                if (bFoundCustomer)
                {
                    Console.WriteLine("Welcome Back " + sCustomerName + "!\n What product category are you looking for today?"); // After this line should display all product category
                    using (DatabaseContext context = new())
                    {
                        foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                        {
                            Console.WriteLine(productCategory.Id + " " + productCategory.CategoryName);
                        }
                    }
                    Console.WriteLine("\n Enter the Product Category You Want: ");
                    int iProductCategory = Int32.Parse((Console.ReadLine() ?? " ").Trim());

                    using (DatabaseContext context = new())
                    {
                        // Output All the products from the chosen Product Category
                        foreach (Product product in context.Products.Where(p => p.ProductCategoryId == iProductCategory).ToList())
                        {
                            Console.Clear();
                            Console.WriteLine("\t" + product.Id + "  " + product.ProductName);
                        }
                    }
                    PickProduct:
                    Console.WriteLine("\n Enter the Product ID NUMBER of the PRODUCT you want to ORDER? ");
                    int iProductSelectID = Int32.Parse(Console.ReadLine() ?? " ".Trim());

                    try
                    {
                        //testing purposes below
                        Console.WriteLine("\t the Customer is: " + sCustomerName);
                        Console.WriteLine("\t the customer ID is: " + iCustomerID);
                        Console.WriteLine("\t the customer address is: " + sCustAddress);
                        Console.WriteLine("\t the product category selected is: " + iProductCategory + "\n\tThe product selected ID is: " + iProductSelectID );
                      /*  using (DatabaseContext context = new())
                        {
                            context.Transactions.Add(new Transaction()  //Need to have all the customer Info wrote to the Transaction table here
                            {

                            });
                        }
                      */
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Processing order.  Please try again...press any key to continue..." + ex.Message);
                        Console.ReadKey();
                        goto PickProduct;
                    }


                }
            }

            // Admin Menu
            else if (input == "2")
            {
                Console.WriteLine("\n Enter your Admin User Name: ");
                username = Console.ReadLine();
                Console.WriteLine("\n Enter your Admin Password: ");
                string? userPassword = Console.ReadLine();

                if ((username != adminName) || (userPassword != adminPassword))
                {
                    Console.WriteLine("Incorrect. Try Again!");
                    Console.ReadKey();
                }
                else
                {
                    //  Admin Menu
                    // ------------
                    // 1) Add Stock
                    // 2) Remove Stock
                    // 3) Flag product as discontinued
                    // 0) Exit
                    int adminSelection = -1;
                    while (adminSelection != 4)
                    {
                    AdminMenu:
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t\tBits & Bytes Admin Menu\n\n\t\t1) Add Stock to Inventory\n\t\t2) Remove Stock from Inventory\n\t\t3) Flag Stock as DISCONTINUED\n\t\t4) Log Out of ADMIN MENU\n\n\t\t\tPlease make your selection: ");

                        try
                        {
                            adminSelection = Int32.Parse((Console.ReadLine() ?? " ").Trim());
                            switch (adminSelection)
                            {
                                case 1://add stock
                                    addStock();
                                    break;

                                case 2://remove stock
                                    removeStock();
                                    break;

                                case 3://flag stock as discontinued
                                    flagProduct();
                                    break;

                                case 4://log out
                                    goto Start;

                                default:
                                    break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Not a good menu choice!  Dummy...\n\tPress any key to continue.......");
                            Console.ReadKey();

                            goto AdminMenu;
                        }
                    }
                }
            }

            // Exit System
            else if (input == "3")
            {
                Console.WriteLine("\n Goodbye " + "\n");
                bInMenu = false;
            }

            // 
            else // Invalid entry point by user
            {
                Console.WriteLine("\n * * * Invalid Menu Selection, Try Again * * *\n");
                Console.ReadKey();
            }
        }

        static void addStock()
        {
            Console.WriteLine("Adding Stock");
            Console.WriteLine("Select Your Product Category:");
            using (DatabaseContext context = new())
            {
                foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                {
                    Console.WriteLine(productCategory.Id + " " + productCategory.CategoryName);
                }
            }
            Console.WriteLine("\n Enter the Product Category You Want: ");
            int ProductCategory = Int32.Parse((Console.ReadLine() ?? " ").Trim());
        }

        static void removeStock()
        {
            Console.WriteLine("\tRemoving stock...please wait a moment...");
            Console.WriteLine("Select Your Product Category:");
            using (DatabaseContext context = new())
            {
                foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                {
                    Console.WriteLine(productCategory.Id + " " + productCategory.CategoryName);
                }
            }
            Console.WriteLine("\n Enter the Product Category You Want: ");
            int ProductCategory = Int32.Parse((Console.ReadLine() ?? " ").Trim());
        }

        static void flagProduct()
        {
            Console.WriteLine("\tFlagging Stock for DISCONTINUATION...please wait a moment...");
            using (DatabaseContext context = new())
            {
                foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                {
                    Console.WriteLine("\t" + productCategory.Id + " " + productCategory.CategoryName);
                }
            }

             Console.WriteLine("\n\tEnter the Product Category Number You Want to DISCONTINUE: ");
             int iProductCategory = Int32.Parse((Console.ReadLine() ?? " ").Trim());

            using (DatabaseContext context = new())
             {
                 foreach (Product product in context.Products.Where(p => p.ProductCategoryId == iProductCategory).ToList())
                 {
                   
                    Console.WriteLine("\t" + product.Id + "  " + product.ProductName);
                    Console.ReadKey();
                 }
             }

            Console.WriteLine("\n Enter the Product ID NUMBER of the PRODUCT you want to DISCONTINUE");
            int iProductSelectID = Int32.Parse(Console.ReadLine() ?? " ".Trim());

            

        }
    }
 }
