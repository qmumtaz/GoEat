using System.Diagnostics.CodeAnalysis;

namespace GoEat.Logic.Order.Exceptions;

[ExcludeFromCodeCoverage]
public class NotAValidGuidException : BaseException
{
    public NotAValidGuidException()
        : base("Not a valid guid.")
    {
    }
}
