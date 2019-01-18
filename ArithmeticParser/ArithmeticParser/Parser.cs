using ArithmeticParser.Tokens;
using System;
using System.Collections.Generic;

namespace ArithmeticParser
{
    public class Parser
    {
        /// <summary>
        /// Tokens to enumerate over
        /// </summary>
        private readonly IEnumerator<Token> tokens;

        /// <summary>
        /// Create a parser with tokens as input
        /// </summary>
        /// 
        /// <param name="input">
        /// The tokens to parse
        /// </param>
        public Parser(IEnumerable<Token> input) => 
            tokens = input.GetEnumerator();

        /// <summary>
        /// Parse the given tokens to get the result
        /// </summary>
        /// 
        /// <returns>
        /// The result of parsing the tokens
        /// </returns>
        public int Parse() => Expression();

        // Expression := Integer {Operator Integer}
        private int Expression()
        {
            tokens.MoveNext();
            var result = Integer();

            while (tokens.MoveNext())
            {
                var op = Operator();
                tokens.MoveNext();
                var num = Integer();

                if (op is AddToken)
                {
                    result += num;
                }
                else if (op is SubtractToken)
                {
                    result -= num;
                }
                else if (op is MultiplyToken)
                {
                    result *= num;
                }
                else
                {
                    throw new ArgumentException("Unsupported operator");
                }
            }

            return result;
        }

        // Operator := '+' | '-' | '*'
        private OperatorToken Operator()
        {
            if (tokens.Current is OperatorToken op)
            {
                return op;
            }

            throw new ArgumentException(
                $"Expected operator but got {tokens.Current}");
        }

        // Integer := Digit{Digit}
        private int Integer()
        {
            if (tokens.Current is IntegerToken)
            {
                return ((IntegerToken)tokens.Current).Value;
            }

            throw new ArgumentException(
                $"Expected integer but got {tokens.Current}");
        }
    }
}
