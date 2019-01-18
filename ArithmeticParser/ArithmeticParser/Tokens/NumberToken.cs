namespace ArithmeticParser.Tokens
{
    public class NumberToken : Token
    {
        public double Value { get; }

        public NumberToken(double value)
        {
            Value = value;
        }
    }
}
