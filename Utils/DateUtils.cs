using System.Globalization;

namespace GymApi;

public class DateUtils
{
    protected DateUtils(){}
    public static int GetYearsFromDates(DateTime startDate, DateTime endDate)
    {
        return (int) (startDate.Date - endDate.Date).TotalDays / 365;
    }

    public static DateTime AddDaysToDate(DateTime date, int days)
    {
        return date.Date.AddDays(days);
    }

    public static string FormatDate(DateTime date)
    {
        return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }

    public static double GetDaysBetweenDates(DateTime startDate, DateTime endDate)
    {
        return startDate.Date.Subtract(endDate.Date).TotalDays;
    }
}
