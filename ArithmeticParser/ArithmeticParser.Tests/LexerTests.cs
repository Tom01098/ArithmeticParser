using ArithmeticParser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ArithmeticParser.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void Integer()
        {
            var tokens = new Lexer().Lex("3");

            Assert.IsInstanceOfType(tokens[0], typeof(IntegerToken));
            Assert.AreEqual(3, ((IntegerToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Integer2()
        {
            var tokens = new Lexer().Lex("34");

            Assert.IsInstanceOfType(tokens[0], typeof(IntegerToken));
            Assert.AreEqual(34, ((IntegerToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Integer3()
        {
            var tokens = new Lexer().Lex("729");

            Assert.IsInstanceOfType(tokens[0], typeof(IntegerToken));
            Assert.AreEqual(729, ((IntegerToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Add()
        {
            var tokens = new Lexer().Lex("+");

            Assert.IsInstanceOfType(tokens[0], typeof(AddToken));
        }

        [TestMethod]
        public void Subtract()
        {
            var tokens = new Lexer().Lex("-");

            Assert.IsInstanceOfType(tokens[0], typeof(SubtractToken));
        }

        [TestMethod]
        public void Multiply()
        {
            var tokens = new Lexer().Lex("*");

            Assert.IsInstanceOfType(tokens[0], typeof(MultiplyToken));
        }

        [TestMethod]
        public void Multiple()
        {
            var tokens = new Lexer().Lex("3 + 4");

            Assert.AreEqual(3, tokens.Count);
            Assert.IsInstanceOfType(tokens[0], typeof(IntegerToken));
            Assert.AreEqual(3, ((IntegerToken)tokens[0]).Value);
            Assert.IsInstanceOfType(tokens[1], typeof(AddToken));
            Assert.IsInstanceOfType(tokens[2], typeof(IntegerToken));
            Assert.AreEqual(4, ((IntegerToken)tokens[2]).Value);
        }

        [TestMethod]
        public void Multiple2()
        {
            var tokens = new Lexer().Lex("729 - 32 * 22");

            Assert.AreEqual(5, tokens.Count);
            Assert.IsInstanceOfType(tokens[0], typeof(IntegerToken));
            Assert.AreEqual(729, ((IntegerToken)tokens[0]).Value);
            Assert.IsInstanceOfType(tokens[1], typeof(SubtractToken));
            Assert.IsInstanceOfType(tokens[2], typeof(IntegerToken));
            Assert.AreEqual(32, ((IntegerToken)tokens[2]).Value);
            Assert.IsInstanceOfType(tokens[3], typeof(MultiplyToken));
            Assert.IsInstanceOfType(tokens[4], typeof(IntegerToken));
            Assert.AreEqual(22, ((IntegerToken)tokens[4]).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid()
        {
            var tokens = new Lexer().Lex("w");
        }
    }
}
