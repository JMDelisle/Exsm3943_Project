using System;
using System.IO;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

class Program
{
    public static List<int> discontinuedProduct = new List<int>();
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
        string? sProdCat;
        decimal dProdPrice = 0;
        bool bQtyAvailable = false;
        
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
            Console.Write(" Please choose: ");
            string? input = Console.ReadLine();

            // Customer Login to their account
            if (input == "1")
            {

                Console.Write("\n Enter your account phone number: ");
                string? sCustomerPhoneNumber = Console.ReadLine();
                // Querry on database for the customers table on the phone number column
                using (DatabaseContext context = new())
                {
                    //Debug: Sandy, 321-999-5657
                    try
                    {
                        var oCust = context.Customers.Where(customer => customer.PhoneNumber == sCustomerPhoneNumber).Single();
                        // Console.WriteLine("Yes!  " + oCust.NameFirst);
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
                    Console.Write("\n Phone number not found, Would you like to add it to the system [Y/N]? ");
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
                            Console.WriteLine("\n New Customer Added.");
                            bFoundCustomer = true;
                        }
                        catch
                        {
                            Console.Write("\n Customer Add FAILED.");
                            Console.ReadKey();
                            bFoundCustomer = false;
                        }
                    }
                }

                // Customer Phone Number / Account Found! 
                if (bFoundCustomer)
                {
                    Console.WriteLine("\n Welcome Back " + sCustomerName + "!\n What product category are you looking for today?"); // After this line should display all product category

                    Console.WriteLine("\n Product Category List: ");
                    Console.WriteLine("\tID\tDescription");
                    Console.WriteLine("\t---|-----------------");

                    using (DatabaseContext context = new())
                    {
                        foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                        {
                            Console.WriteLine("\t" + productCategory.Id + "\t" + productCategory.CategoryName);
                        }
                    }
                    Console.Write("\n Enter the Product Category You Want: ");
                    int iProductCategory = Int32.Parse((Console.ReadLine() ?? " ").Trim());
                    sProdCat = "";
                    using (DatabaseContext context = new())
                    {
                        try
                        {
                            var oProdCat = context.ProductCategories.Where(category => category.Id == iProductCategory).Single();
                            Console.WriteLine("Yes!  " + oProdCat.CategoryName);
                            sProdCat = oProdCat.CategoryName;
                        }
                        catch
                        {
                            Console.WriteLine(" Error looking up Product Category Name.");
                        }
                    }
                    bool bTryAgain = true;
                    while (bTryAgain)
                    {
                        // Clear console and display all products, could use a counter to display product in pages in Version 2.0
                        Console.Clear();
                        Console.WriteLine("\n Product List for Category: " + sProdCat);
                        Console.WriteLine("\tID\tDescription\tIn Stock");
                        Console.WriteLine("\t---|-----------------|----------");

                        using (DatabaseContext context = new())
                        {
                            // Output All the products from the chosen Product Category
                            foreach (Product product in context.Products.Where(p => p.ProductCategoryId == iProductCategory).ToList())
                            {
                                Console.WriteLine("\t" + product.Id + "\t" + product.ProductName + "\t" + product.QuantityOnHand);
                            }
                        }

                        Console.Write("\n Enter the Product ID you want to Order: ");
                        int iProductID = Int32.Parse(Console.ReadLine() ?? " ".Trim());
                        Console.Write("\n What Quantity do you want to Order: ");
                        int iProductQty = Int32.Parse(Console.ReadLine() ?? " ".Trim());
                        bQtyAvailable = false;
                        // Do what have the requested quantity of Product on Hand right now?
                        using (DatabaseContext context = new())
                        {
                            try
                            {
                                var oProduct = context.Products.Where(product => product.Id == iProductID).Single();
                                Console.WriteLine("Yes!  " + oProduct.ProductName + " qty on hand: " + oProduct.QuantityOnHand);
                                if (iProductQty > oProduct.QuantityOnHand)
                                {
                                    Console.WriteLine(" You are attempting to order more product than is available.");
                                }
                                else
                                {
                                    dProdPrice = oProduct.SalePrice;
                                    bQtyAvailable = true;
                                }

                            }
                            catch
                            {
                                Console.WriteLine(" Error looking up Product details.");
                            }
                        }

                        // If we have enough product qantity on hand lets create a transaction and
                        // then take the ordered quantity out of inventory
                        if (bQtyAvailable)
                        {/* Need to set a variable to save the extended price, and the total price to save into the Transaction table */
                            try
                            {
                                using (DatabaseContext context = new())
                                {
                                    Transaction newtrans = new Transaction();
                                    newtrans.CustomerId = iCustomerID;
                                    newtrans.ProductCategoryId = iProductID;
                                    newtrans.ProductCategoryId = iProductID;
                                    newtrans.TimeDateOfOrder = DateTime.Now;
                                    newtrans.QuantityOrdered = iProductQty;
                                    newtrans.IndividualPrice = dProdPrice;
                                    newtrans.ExtendedPrice = dProdPrice * iProductQty;
                                    newtrans.TotalPrice = dProdPrice * iProductQty;
                                    context.Add(newtrans);
                                    context.SaveChanges();
                                }
                                Console.WriteLine("\n New Transaction Added.");

                            }
                            catch
                            {
                                Console.Write("\n Transaction Add FAILED.");
                            }
                            // Take the ORDERED amount of Product OUT of INVENTORY 

                        }
                        Console.ReadKey();
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
                    //  Admin Menu Here
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
                Console.Write("\n * * * Invalid Menu Selection, Try Again * * *\n");
                Console.ReadKey();
            }
        }

        static void addStock()
        {
            int iProductCategory = -1;
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
            try
            {
                iProductCategory = Int32.Parse((Console.ReadLine() ?? " ").Trim());
                if (iProductCategory < 1 || iProductCategory > 5)
                {
                    Console.WriteLine("\n *** INVALID CATEGORY ... PRESS ANY KEY TO CONTINUE ***\n");
                    Console.ReadKey();
                    return;
                }
            }
            catch
            {
                Console.Write("Invalid selection");
                Console.ReadKey();
                return;
            }
            using (DatabaseContext context = new())
            {
                foreach (Product product in context.Products.Where(prod => prod.ProductCategoryId == iProductCategory))
                {
                    Console.WriteLine(product.Id + "   " + product.ProductName);
                }
                Console.WriteLine("Choose your Product (by number): ");
                Console.ReadLine();
            }

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
            int iProductCategory = -1;
            int iProductSelectID = -1;
            Console.WriteLine("\tFlagging Stock for DISCONTINUATION...please wait a moment...");
            using (DatabaseContext context = new())
            {
                foreach (ProductCategory productCategory in context.ProductCategories.ToList())
                {
                    Console.WriteLine("\t" + productCategory.Id + " " + productCategory.CategoryName);
                }
            }

             Console.WriteLine("\n\tEnter the Product Category Number You Want to DISCONTINUE: ");
            try
            {
                 iProductCategory = Int32.Parse((Console.ReadLine() ?? " ").Trim());
            }
            catch
            {
                Console.WriteLine("Not a valid choice!");
            }
            using (DatabaseContext context = new())
             {
                 foreach (Product product in context.Products.Where(p => p.ProductCategoryId == iProductCategory).ToList())
                 {                   
                    Console.WriteLine("\t" + product.Id + "  " + product.ProductName);
                 }
             }
            Console.WriteLine("\n Enter the Product ID NUMBER of the PRODUCT you want to DISCONTINUE");
            try
            {
                iProductSelectID = Int32.Parse(Console.ReadLine() ?? " ".Trim());
            }
            catch
            {
                Console.WriteLine("Not a valid choice!");
            }
            discontinuedProduct.Add(iProductSelectID);

            Console.WriteLine(discontinuedProduct);

        }

    }
 }
