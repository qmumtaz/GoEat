using System.Diagnostics.CodeAnalysis;

namespace GoEat.Logic.Order.Exceptions;

[ExcludeFromCodeCoverage]
public class GuidCannotBeEmptyException : BaseException
{
    public GuidCannotBeEmptyException()
        : base("Guid cannot be empty guid.")
    {
    }
}
