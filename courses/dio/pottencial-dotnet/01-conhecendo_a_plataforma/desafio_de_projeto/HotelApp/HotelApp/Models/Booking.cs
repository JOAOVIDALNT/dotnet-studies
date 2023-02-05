namespace HotelApp.Models;

public class Booking
{
    public List<Person> Guests { get; set; }
    public Suite Suite { get; set; }
    public int DaysReserved { get; set; }

    public Booking()
    {
    }

    public Booking(int daysReserved)
    {
        DaysReserved = daysReserved;
    }

    public void RegisterGuests(List<Person> guests)
    {
        if (Suite.Capacity >= guests.Count)
        {
            Guests = guests;
        }
        else
        {
            throw new Exception("Room's doesn't support the quantity of guests");
        }
    }

    public void RegisterSuite(Suite suite)
    {
        Suite = suite;
    }

    public int GetGuestsCount()
    {
        return Guests.Count;
    }

    public decimal DayliValueCalc()
    {
        decimal value = Suite.DayliValue;

        if (DaysReserved >= 10)
        {
            value -= value * 10M / 100M;
        }

        return value;
    }
}