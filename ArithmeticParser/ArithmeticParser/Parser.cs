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
        public double Parse() => Expression();

        // Expression := Number {Operator Number}
        private double Expression()
        {
            tokens.MoveNext();
            var result = Number();

            while (tokens.MoveNext())
            {
                var op = Operator();
                tokens.MoveNext();
                var num = Number();

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
                else if (op is DivideToken)
                {
                    result /= num;
                }
                else
                {
                    throw new ArgumentException("Unsupported operator");
                }
            }

            return result;
        }

        // Operator := '+' | '-' | '*' | '/'
        private OperatorToken Operator()
        {
            if (tokens.Current is OperatorToken op)
            {
                return op;
            }

            throw new ArgumentException(
                $"Expected operator but got {tokens.Current}");
        }

        // Number := Digit{Digit} | Digit{Digit}.Digit{Digit}
        private double Number()
        {
            if (tokens.Current is NumberToken)
            {
                return ((NumberToken)tokens.Current).Value;
            }

            throw new ArgumentException(
                $"Expected integer but got {tokens.Current}");
        }
    }
}
