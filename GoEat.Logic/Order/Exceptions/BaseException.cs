using System.Diagnostics.CodeAnalysis;

namespace GoEat.Logic.Order.Exceptions;

[ExcludeFromCodeCoverage]
public class BaseException : Exception
{
    private readonly string message;

    public BaseException(string message)
        : base(message)
    {
        this.message = message;
    }
}
