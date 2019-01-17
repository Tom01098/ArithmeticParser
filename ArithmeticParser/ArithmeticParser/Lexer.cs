using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ArithmeticParser.Tokens;
using static System.Char;

namespace ArithmeticParser
{
    public class Lexer
    {
        private const char EOF = '\uffff';

        /// <summary>
        /// Return a list of tokens based off an input string
        /// </summary>
        /// 
        /// <param name="str">
        /// The input string to lex
        /// </param>
        /// 
        /// <returns>
        /// A list of tokens representing the string
        /// </returns>
        public List<Token> Lex(string str)
        {
            StringReader reader;
            var current = ' ';

            using (reader = new StringReader(str))
            {
                var tokens = new List<Token>();
                var builder = new StringBuilder();

                ReadNextChar();

                // Keep looping until EOF is reached
                while (true)
                {
                    // Digits
                    if (IsDigit(current))
                    {
                        do
                        {
                            builder.Append(current);
                            ReadNextChar();
                        }
                        while (IsDigit(current));

                        tokens.Add(new IntegerToken(
                            int.Parse(builder.ToString())));

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
                    // Multiply
                    else if (current == '*')
                    {
                        tokens.Add(new MultiplyToken());
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
                            $"{current} is an invalid character");
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
