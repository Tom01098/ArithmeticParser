﻿using ArithmeticParser.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Char;

namespace ArithmeticParser
{
    public class Lexer
    {
        /// <summary>
        /// End-of-file character
        /// </summary>
        private const char EOF = '\uffff';

        /// <summary>
        /// The input string to lex
        /// </summary>
        private readonly string str;

        /// <summary>
        /// Create a lexer with the given string as input
        /// </summary>
        /// 
        /// <param name="str">
        /// The input string to lex
        /// </param>
        public Lexer(string str) => this.str = str;

        /// <summary>
        /// Return a list of tokens based off an input string
        /// </summary>
        /// 
        /// <returns>
        /// A list of tokens representing the string
        /// </returns>
        public List<Token> Lex()
        {
            StringReader reader;
            char current;

            using (reader = new StringReader(str))
            {
                var tokens = new List<Token>();
                var builder = new StringBuilder();

                ReadNextChar();

                // Keep looping until EOF is reached
                while (true)
                {
                    // Number
                    if (IsDigit(current))
                    {
                        int decimalCount = 0;

                        do
                        {
                            if (current == '.')
                            {
                                if (decimalCount == 1)
                                {
                                    throw new ArgumentException(
                                        "Only one decimal point " +
                                        "is allowed in a number");
                                }

                                decimalCount++;
                            }

                            builder.Append(current);
                            ReadNextChar();
                        }
                        while (IsDigit(current) || current == '.');

                        tokens.Add(new NumberToken(
                            double.Parse(builder.ToString())));

                        builder.Clear();

                        continue;
                    }
                    // Add
                    else if (current == '+')
                    {
                        tokens.Add(new AddToken());
                    }
                    // Subtract
                    else if (current == '-')
                    {
                        tokens.Add(new SubtractToken());
                    }
                    // Multiply/Exponent
                    else if (current == '*')
                    {
                        ReadNextChar();

                        if (current == '*')
                        {
                            tokens.Add(new ExponentToken());
                        }
                        else
                        {
                            tokens.Add(new MultiplyToken());
                            continue;
                        }
                    }
                    // Divide
                    else if (current == '/')
                    {
                        tokens.Add(new DivideToken());
                    }
                    // Open Parenthesis
                    else if (current == '(')
                    {
                        tokens.Add(new OpenParenthesisToken());
                    }
                    // Close Parenthesis
                    else if (current == ')')
                    {
                        tokens.Add(new CloseParenthesisToken());
                    }
                    // EOF
                    else if (current == EOF)
                    {
                        break;
                    }
                    // Invalid character
                    else if (!IsWhiteSpace(current))
                    {
                        throw new ArgumentException(
                            $"'{current}' is an invalid character");
                    }

                    ReadNextChar();
                }

                return tokens;
            }

            // Local function for reading the next char
            void ReadNextChar() => current = (char)reader.Read();
        }
    }
}
