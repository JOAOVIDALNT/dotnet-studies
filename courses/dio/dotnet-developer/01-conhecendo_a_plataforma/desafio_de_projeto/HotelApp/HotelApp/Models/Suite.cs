using System.Runtime;

namespace HotelApp.Models;

public class Suite
{
    public string SuiteType { get; set; }
    public int Capacity { get; set; }
    public decimal DayliValue  { get; set; }

    public Suite(string suiteType, int capacity, decimal dayliValue)
    {
        SuiteType = suiteType;
        Capacity = capacity;
        DayliValue = dayliValue;
    }

    public Suite()
    {
    }
}