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
            var tokens = new Lexer("3").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(NumberToken));
            Assert.AreEqual(3, ((NumberToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Integer2()
        {
            var tokens = new Lexer("34").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(NumberToken));
            Assert.AreEqual(34, ((NumberToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Integer3()
        {
            var tokens = new Lexer("729").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(NumberToken));
            Assert.AreEqual(729, ((NumberToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Decimal()
        {
            var tokens = new Lexer("1.1").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(NumberToken));
            Assert.AreEqual(1.1, ((NumberToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Decimal2()
        {
            var tokens = new Lexer("332.87").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(NumberToken));
            Assert.AreEqual(332.87, ((NumberToken)tokens[0]).Value);
        }

        [TestMethod]
        public void Negative()
        {
            var tokens = new Lexer("-3.3").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(SubtractToken));
            Assert.IsInstanceOfType(tokens[1], typeof(NumberToken));
            Assert.AreEqual(3.3, ((NumberToken)tokens[1]).Value);
        }

        [TestMethod]
        public void Add()
        {
            var tokens = new Lexer("+").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(AddToken));
        }

        [TestMethod]
        public void Subtract()
        {
            var tokens = new Lexer("-").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(SubtractToken));
        }

        [TestMethod]
        public void Multiply()
        {
            var tokens = new Lexer("*").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(MultiplyToken));
        }

        [TestMethod]
        public void Divide()
        {
            var tokens = new Lexer("/").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(DivideToken));
        }

        [TestMethod]
        public void OpenParenthesis()
        {
            var tokens = new Lexer("(").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(OpenParenthesisToken));
        }

        [TestMethod]
        public void CloseParenthesis()
        {
            var tokens = new Lexer(")").Lex();

            Assert.IsInstanceOfType(tokens[0], typeof(CloseParenthesisToken));
        }

        [TestMethod]
        public void ParenthesisedExpression()
        {
            var tokens = new Lexer("(3 + 4)").Lex();

            Assert.AreEqual(5, tokens.Count);
            Assert.IsInstanceOfType(tokens[0], typeof(OpenParenthesisToken));
            Assert.IsInstanceOfType(tokens[1], typeof(NumberToken));
            Assert.AreEqual(3, ((NumberToken)tokens[1]).Value);
            Assert.IsInstanceOfType(tokens[2], typeof(AddToken));
            Assert.IsInstanceOfType(tokens[3], typeof(NumberToken));
            Assert.AreEqual(4, ((NumberToken)tokens[3]).Value);
            Assert.IsInstanceOfType(tokens[4], typeof(CloseParenthesisToken));
        }

        [TestMethod]
        public void Multiple()
        {
            var tokens = new Lexer("3 + 4").Lex();

            Assert.AreEqual(3, tokens.Count);
            Assert.IsInstanceOfType(tokens[0], typeof(NumberToken));
            Assert.AreEqual(3, ((NumberToken)tokens[0]).Value);
            Assert.IsInstanceOfType(tokens[1], typeof(AddToken));
            Assert.IsInstanceOfType(tokens[2], typeof(NumberToken));
            Assert.AreEqual(4, ((NumberToken)tokens[2]).Value);
        }

        [TestMethod]
        public void Multiple2()
        {
            var tokens = new Lexer("729 - 32 * 22").Lex();

            Assert.AreEqual(5, tokens.Count);
            Assert.IsInstanceOfType(tokens[0], typeof(NumberToken));
            Assert.AreEqual(729, ((NumberToken)tokens[0]).Value);
            Assert.IsInstanceOfType(tokens[1], typeof(SubtractToken));
            Assert.IsInstanceOfType(tokens[2], typeof(NumberToken));
            Assert.AreEqual(32, ((NumberToken)tokens[2]).Value);
            Assert.IsInstanceOfType(tokens[3], typeof(MultiplyToken));
            Assert.IsInstanceOfType(tokens[4], typeof(NumberToken));
            Assert.AreEqual(22, ((NumberToken)tokens[4]).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidCharacter()
        {
            new Lexer("w").Lex();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidDecimal()
        {
            new Lexer("4.6.3").Lex();
        }
    }
}
