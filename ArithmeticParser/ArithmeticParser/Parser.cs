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
        public int Parse()
        {
            throw new NotImplementedException();
        }

        // Expression := Integer {Operator Integer}
        private int Expression()
        {
            throw new NotImplementedException();
        }

        // Integer := Digit{Digit}
        private int Integer()
        {
            throw new NotImplementedException();
        }
    }
}
