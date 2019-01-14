namespace ArithmeticParser.Tokens
{
    public class IntegerToken : Token
    {
        public int Value { get; }

        public IntegerToken(int value)
        {
            Value = value;
        }
    }
}
