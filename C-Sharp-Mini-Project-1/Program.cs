
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Command not understood, please try again.");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Date format error, please try again");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input format error, please type in an integer for the price.");
            Console.ResetColor();
        }
    }

    if (on_exit)
    {
        break;
    }
    else
    {
        if (type == "p")
        {
            assets.Add(new Phone(brand, model, "", pd, price));
        }
        else if (type == "c")
        {
            assets.Add(new Computer(brand, model, "", pd, price));
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Asset successfully added!");
        Console.ResetColor();
    }
}

// display asset list
Console.WriteLine("Type".PadRight(20) + "Brand".PadRight(20) + "Model".PadRight(20) + "Purchase Date".PadRight(20) + "Price in USD".PadRight(20));
Console.WriteLine("----".PadRight(20) + "-----".PadRight(20) + "-----".PadRight(20) + "-------------".PadRight(20) + "------------".PadRight(20));

List<Asset> ordered_list = assets.OrderBy(a => a.GetType().Name).ThenBy(a => a.Purchase_date).ToList();
const int average_year = 365, average_month = 30;

foreach(Asset asset in ordered_list)
{
    TimeSpan age = DateTime.Now - asset.Purchase_date;

    if(age.TotalDays > (average_year*3 - average_month * 3))
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    Console.WriteLine(asset.GetType().Name.PadRight(20) + asset.Brand.PadRight(20) + asset.Model.PadRight(20) + asset.Purchase_date.ToString("MM/dd/yyyy").PadRight(20) + asset.Price.ToString().PadRight(20));
    Console.ResetColor();
}