
using BenchmarkDotNet.Running;
using Library.Entities;
using LibraryAdDbContext;
using LibraryConsoleApp;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

var dbContext = new LibraryAdDbContext.LibraryAdDbContext();
//var users = dbContext.Users;

//foreach (var u in users)
//{
//  Console.WriteLine(u.Name);
//}s

/*
var rentals = dbContext.RentalRecords.Include(d => d.Book)
                                    .Include(d => d.User);

foreach(var r in rentals)
{
    Console.WriteLine($"{r.Book.Name}   {r.User.Name}");
}
*/

/*string bookName = Console.ReadLine();

var rentted = dbContext.RentalRecords.Include(d => d.User)
                                     .ThenInclude(d => d.Addresses) 
                                     .FirstOrDefault(d => d.Book.Name 
                                                == bookName);

if(rentted == null)
{
    Console.WriteLine("Currently available");
}
else
{
    Console.WriteLine($"Currently rented by {rentted.User.Name} expected to be " +
        $"  returned by {rentted.DueDate.ToShortDateString()}");

    Console.WriteLine($"User can be reached at {string.Join(',',rentted.User.Addresses.SelectMany(d => d.Address1))}");
}*/

//Console.WriteLine("Enter the book name :");
//string bookName = Console.ReadLine();

//Console.WriteLine("Enter the email address :");
//string email = Console.ReadLine();

//var book = dbContext.Books.FirstOrDefault(d => d.Name == bookName);
//var user = dbContext.Users.FirstOrDefault(d => d.Email == email);

//if(user != null && book != null)
//{
/*RentalRecord newRental = new RentalRecord
{
    BookId = 2,
    UserId = 1,
    DueDate = DateTime.Now.AddDays(7),
    CreatedDate = DateTime.Now
};

if (dbContext.RentalRecords.Any(d => d.User.Id == 1 && d.Book.Id == 2))
{
    Console.WriteLine("The user has already rented the same book");
}
else
{
    dbContext.RentalRecords.Add(newRental);
    dbContext.SaveChanges();
}*/
//}

/*
var rentals = dbContext.RentalRecords.Where(d => d.UserId == 1);
foreach (var r in rentals)
{
    r.DueDate = new DateTime(2024, 04, 30);
}

dbContext.SaveChanges();*/
/*
var user1 = dbContext.Users.Find(1);
var user2 = dbContext.Users.Find(1);*/


/*var usersEf = new DataServices().TakeTop100EfCore();
var usersAdo = new DataServices().TakeTop100Ado();

var user = new DataServices().FindByIdEfCore();
var userAdo = new DataServices().FindByIdAdo();

Console.WriteLine(usersEf.Count);
Console.WriteLine(usersAdo.Count);

Console.WriteLine(user.Name);
Console.WriteLine(userAdo.Name);*/

BenchmarkRunner.Run<DataServices>();

