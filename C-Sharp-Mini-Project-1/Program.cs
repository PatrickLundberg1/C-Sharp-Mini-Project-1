
using C_Sharp_Mini_Project_1;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

// Level 2, Type/Model/Brand/Date/Price (Office and Currency for level 3)

List<Asset> assets = new List<Asset>();

Console.WriteLine("Welcome to Asset Tracking! Type in \"exit\" at any time to stop the program and display all Assets.");
string input = "", type = "", brand = "", model = "", office = "";
DateTime pd = DateTime.Now;
int price = 0;
bool on_exit = false;

while (true)
{
    while (!on_exit)
    {
        Console.Write("Please input P or C for (P)hone or (C)omputer: ");
        input = (Console.ReadLine() ?? "").Trim().ToLower();

        if(input == "exit")
        {
            on_exit = true;
        }
        else if(input == "p" || input == "c")
        {
            type = input;
            break;
        }
        else
        {
            Console.WriteLine("Command not understood, please try again.");
        }
    }

    while (!on_exit)
    {
        Console.Write("Please input the name of the brand: ");
        input = (Console.ReadLine() ?? "").Trim();

        if (input.ToLower() == "exit")
        {
            on_exit = true;
        }
        else
        {
            brand = input;
            break;
        }
    }

    while (!on_exit)
    {
        Console.Write("Please input the brand model: ");
        input = (Console.ReadLine() ?? "").Trim();

        if (input.ToLower() == "exit")
        {
            on_exit = true;
        }
        else
        {
            model = input;
            break;
        }
    }

    while (!on_exit)
    {
        Console.Write("Please input the purchase date, for example in the format year-month-day: ");
        input = (Console.ReadLine() ?? "").Trim();

        if (input.ToLower() == "exit")
        {
            on_exit = true;
        }
        else if(DateTime.TryParse(input, out pd))
        {
            break;
        }
        else
        {
            Console.WriteLine("Date format error, please try again");
        }
    }

    while (!on_exit)
    {
        Console.Write("Please input the price (USD): ");
        input = (Console.ReadLine() ?? "").Trim();

        if (input.ToLower() == "exit")
        {
            on_exit = true;
        }
        else if(int.TryParse(input, out price))
        {
            break;
        }
        else
        {
            Console.WriteLine("Input format error, please type in an integer for the price.");
        }
    }

    if (on_exit)
    {
        break;
    }
    else if(type == "p")
    {
        assets.Add(new Phone(brand, model, "", pd, price));
    }
    else if(type == "c")
    {
        assets.Add(new Computer(brand, model, "", pd, price));
    }
}

// display asset list
Console.WriteLine("Type".PadRight(20) + "Brand".PadRight(20) + "Model".PadRight(20) + "Purchase Date".PadRight(20) + "Price in USD".PadRight(20));
Console.WriteLine("----".PadRight(20) + "-----".PadRight(20) + "-----".PadRight(20) + "-------------".PadRight(20) + "------------".PadRight(20));

