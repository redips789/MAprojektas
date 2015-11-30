namespace MA.Limits.LimitsDomain
{
    public enum LimitResultType
    {
        RealNumber,
        PositiveInfinity,
        NegativeInfinity,
        DoesNotExist
    }

    public class LimitResult
    {
        public LimitResultType LimitResultType { get; set; }
        public double Value { get; set; }
    }
}
