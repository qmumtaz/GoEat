using GoEat.Logic.Order.Exceptions;

namespace GoEat.Logic.Order.ValueObjects
{
    public record class Id
    {
        public Guid Value { get; }

        public Id()
        {
            Value = Guid.NewGuid();
        }

        public Id(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new GuidCannotBeEmptyException();
            }

            Value = value;
        }

        public Id(string value)
        {
            var isGuid = Guid.TryParse(value, out var val);

            if (!isGuid)
            {
                throw new NotAValidGuidException();
            }

            if (val == Guid.Empty)
            {
                throw new GuidCannotBeEmptyException();
            }

            Value = val;
        }
    }
}
