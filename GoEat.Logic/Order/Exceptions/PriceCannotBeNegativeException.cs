using System.Diagnostics.CodeAnalysis;

namespace GoEat.Logic.Order.Exceptions;

[ExcludeFromCodeCoverage]
public class PriceCannotBeNegativeException : BaseException
{
    public PriceCannotBeNegativeException() : base("Cannot be zero or negative")
    {

    }
}
