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
        public double Parse()
        {
            tokens.Reset();
            tokens.MoveNext();
            return Expression();
        }

        // Expression := Factor {Operator Factor}
        private double Expression()
        {
            var result = Factor();

            while (tokens.MoveNext() && tokens.Current is OperatorToken op)
            {
                tokens.MoveNext();
                var num = Factor();

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
                    throw new ArgumentException(
                        $"Unsupported operator '{op}'");
                }
            }

            return result;
        }

        // Factor := Number | '(' Expression ')'
        private double Factor()
        {
            if (tokens.Current is OpenParenthesisToken)
            {
                tokens.MoveNext();
                var result = Expression();

                if (!(tokens.Current is CloseParenthesisToken))
                {
                    throw new ArgumentException(
                        $"Expected ')' but got '{tokens.Current}'");
                }

                return result;
            }
            else
            {
                return Number();
            }
        }

        // Number := [-](Integer | Integer.Integer)
        private double Number()
        {
            bool isNegative = false;

            if (tokens.Current is SubtractToken)
            {
                isNegative = true;
                tokens.MoveNext();
            }

            if (tokens.Current is NumberToken)
            {
                double value = ((NumberToken)tokens.Current).Value;
                return isNegative ? -value : value;
            }

            throw new ArgumentException(
                $"Expected a number but got '{tokens.Current}'");
        }
    }
}
