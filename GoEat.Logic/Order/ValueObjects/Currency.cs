using System.Globalization;

namespace GoEat.Logic.Order.ValueObjects;

public class Currency
{
    public static string IsoCode => "GBP";

    public static string Name => "United Kingdom Pound";

    public static CultureInfo CultureInfo => new("en-GB");
}
