using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ArithmeticParser.Tests
{
    [TestClass]
    public class CombinedTests
    {
        [TestMethod]
        public void SingleNumber()
        {
            var str = "3";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Simple()
        {
            var str = "3.3 + 4";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();

            Assert.AreEqual(7.3, result);
        }

        [TestMethod]
        public void Simple2()
        {
            var str = "5 * 2.2";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Parenthesised()
        {
            var str = "(2 + 1)";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Parenthesised2()
        {
            var str = "3 + (4 * 5)";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();

            Assert.AreEqual(23, result);
        }

        [TestMethod]
        public void Complex()
        {
            var str = "(3 / 2) - (2 - 1)";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();

            Assert.AreEqual(.5, result);
        }

        [TestMethod]
        public void Complex2()
        {
            var str = "((2 / 4) + (7 / 2)) + 1";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid()
        {
            var str = "3 + ";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid2()
        {
            var str = "-";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid3()
        {
            var str = "(4 - )";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid4()
        {
            var str = "(3 + 2";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid5()
        {
            var str = "6 * ()";

            var tokens = new Lexer(str).Lex();
            var result = new Parser(tokens).Parse();
        }
    }
}
