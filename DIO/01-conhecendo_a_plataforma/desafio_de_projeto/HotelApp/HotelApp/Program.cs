using System.Security.Principal;
using System.Text;
using HotelApp.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Person> guests =  new List<Person>();

Person p1 = new Person("Guest 1");
Person p2 = new Person("Guest 2");


guests.Add(p1);
guests.Add(p2);

Suite suite = new Suite("Premium", 2, 30);

Booking booking = new Booking(10);
booking.RegisterSuite(suite);
booking.RegisterGuests(guests);

Console.WriteLine($"Guests: {booking.GetGuestsCount()}");
Console.WriteLine($"Dayli Value: {booking.DayliValueCalc()}");
