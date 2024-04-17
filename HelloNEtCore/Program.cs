
#region Config Part
using HelloNEtCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;

// See https://aka.ms/new-console-template for more information

/*
Console.WriteLine("Hello, World!");
Console.WriteLine(new { Greeting = "Hello There", Name = "Sreehari" });

Encoding.ASCII.GetBytes("TEst");

var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appSettings.json")
                        .Build();

var connectionStr = config["ConnectionStrings:Default"];
Console.WriteLine(connectionStr);

var themes = config.GetSection("Theme")
                    .Get<List<Theme>>();

foreach (var item in themes)
{
    Console.WriteLine(item);
}

*/
#endregion

/*var articleDateTime = DateTime.Now.ToString();
var article = $"""
            Hello there 
            this is a large article 
            With multiple lines and paragahs,
                   This is the start of a new 
                   Paragrah
                   {articleDateTime}
            """;

Console.WriteLine(article);

var enmployee = new Employee
{
    Name = "Sree"
};


enmployee.Name = "Jhon";



//var emp = new Employee("Sree");

(string Name, float Salary) empSalary = ("Sreehari", 50000);

Console.WriteLine(empSalary.Name);
Console.WriteLine(empSalary.Salary);

var tax = TaxCalculator.CalculateTax((600000,false));

Console.WriteLine($"""
        Per : {tax.totalPer},
        Tax : {tax.totalTax},
        Total Amount With Tax : {tax.netAmount}
    """);

var jwtToken1 = Authenticate.SignIn("u", "p");
var jwtToken2 = Authenticate.SignIn("a", "p");

Console.WriteLine(jwtToken1);*/

/*
var account1 = new Account { AccountNumber = 10001, Name = "Sree" };
var account2 = new Account { AccountNumber = 10001, Name = "Jhon" };

List<Account> accoutns = new List<Account>();
accoutns.Add(account1);

if(accoutns.Contains(account2))
{ }


if (account1.Equals(account2))
{
    Console.WriteLine("They are same");
}
else
{
    Console.WriteLine("Diff Accounts");
}*/

/*
var a1 = new Account {  Name = "A" , AccountNo = 10001};
var a2 = new Account { Name = "A", AccountNo = 10001 };

if (a1 == a2)
{
    Console.WriteLine("Both are same accounts");
}
else
    Console.WriteLine("Both are diff accounts");

var a3 = a1 with { Name = "Jhon" };
Console.WriteLine(a3); */

// public record AppTheme(string baseColor, string font);

/*AppTheme defaultTheme = new("Blue", "Arial");
var darkTheme = defaultTheme with { baseColor = "Black" };*/

/*
dynamic marks = "A";

switch(marks)
{
    case string grade when grade == "A" :
          Console.WriteLine($"Candidate is selected {grade}");break;
    case int m when m > 550 :
        Console.WriteLine($"Mark based assesment {m}");break;
    default: 
        Console.WriteLine("Not eligible for grading");break;

}*/

var a1 = new Account { Name = "Sreehari", AccountNo = 10001, Age = 31 };
var a2 = new Account { Name = "Jhon", AccountNo = 1002, Age = 17 };

switch(a1)
{
    case { Age : > 30  }:
        Console.WriteLine("Premium Customer");break;
    case { Name: "Jhon" }:
        Console.WriteLine("Regular Customer"); break;

}

string[] cities = { "Bangalore", "Chennei", "Trivandrum" };
string[] myPrefCities = { "Bangalore", "Chennei" };


Console.WriteLine(cities is ["Bangalore", "Chennei", "Trivandrum"] );

