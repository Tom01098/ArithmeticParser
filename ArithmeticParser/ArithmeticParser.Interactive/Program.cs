using System;

namespace ArithmeticParser.Interactive
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter an arithmetic expression to evaluate");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                var input = Console.ReadLine();

                try
                {
                    var tokens = new Lexer(input).Lex();

                    var result = new Parser(tokens).Parse();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
