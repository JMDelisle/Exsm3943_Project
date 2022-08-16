using System;
using System.IO;

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

    Start:
        Console.WriteLine(" 1) Register\n 2) Login\n 3) Purchase\n 0) Exit\n\t Please choose:  ");
        var input = Console.ReadLine();



        bool successfull = false;
        while (!successfull)
        {

            if (input == "1")
            {

                Console.WriteLine("Enter your username:");
                var username = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                var password = Console.ReadLine();


                Array.Resize(ref arrUsers, arrUsers.Length + 1);
                arrUsers[arrUsers.Length - 1] = new Users(username, password);
                successfull = true;
                goto Start;

            }

            else if (input == "2")
            {
                Console.WriteLine("Write your username:");
                var username = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                var password = Console.ReadLine();


                foreach (Users user in arrUsers)
                {
                    if (username == user.username && password == user.password)
                    {
                        Console.WriteLine("You have successfully logged in !!!");
                        Console.ReadLine();
                        successfull = true;
                        break;
                    }
                }

                if (!successfull)
                {
                    Console.WriteLine("Your username or password is incorect, try again !!!");
                }

            }


            else if (input == "0")
            {// End programs 
                break;

            }



            else
            {
                Console.WriteLine("Try again !!!");
                break;


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
