using ArithmeticParser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ArithmeticParser.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void SingleNumber()
        {
            var tokens = new List<Token>
            {
                new NumberToken(3)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void SingleNumber2()
        {
            var tokens = new List<Token>
            {
                new NumberToken(3.5)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(3.5, result);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            var tokens = new List<Token>
            {
                new SubtractToken(),
                new NumberToken(3.5)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(-3.5, result);
        }

        [TestMethod]
        public void Add()
        {
            var tokens = new List<Token>
            {
                new NumberToken(54),
                new AddToken(),
                new NumberToken(2)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(56, result);
        }

        [TestMethod]
        public void Subtract()
        {
            var tokens = new List<Token>
            {
                new NumberToken(54),
                new SubtractToken(),
                new NumberToken(2)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(52, result);
        }

        [TestMethod]
        public void Multiply()
        {
            var tokens = new List<Token>
            {
                new NumberToken(3),
                new MultiplyToken(),
                new NumberToken(2)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Divide()
        {
            var tokens = new List<Token>
            {
                new NumberToken(3),
                new DivideToken(),
                new NumberToken(2)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(1.5, result);
        }

        [TestMethod]
        public void Exponent()
        {
            var tokens = new List<Token>
            {
                new NumberToken(3),
                new ExponentToken(),
                new NumberToken(2)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void ParenthesisedNumber()
        {
            var tokens = new List<Token>
            {
                new OpenParenthesisToken(),
                new NumberToken(3.4),
                new CloseParenthesisToken()
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(3.4, result);
        }

        [TestMethod]
        public void ParenthesisedNumber2()
        {
            var tokens = new List<Token>
            {
                new OpenParenthesisToken(),
                new SubtractToken(),
                new NumberToken(3.4),
                new CloseParenthesisToken()
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(-3.4, result);
        }

        [TestMethod]
        public void Multiple()
        {
            var tokens = new List<Token>
            {
                new NumberToken(54),
                new SubtractToken(),
                new NumberToken(52),
                new MultiplyToken(),
                new NumberToken(4)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Multiple2()
        {
            var tokens = new List<Token>
            {
                new NumberToken(54),
                new AddToken(),
                new NumberToken(2),
                new AddToken(),
                new NumberToken(5)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(61, result);
        }

        [TestMethod]
        public void Multiple3()
        {
            var tokens = new List<Token>
            {
                new NumberToken(5),
                new AddToken(),
                new NumberToken(13),
                new DivideToken(),
                new NumberToken(2)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Multiple4()
        {
            var tokens = new List<Token>
            {
                new NumberToken(6.1),
                new AddToken(),
                new NumberToken(3.5),
                new SubtractToken(),
                new NumberToken(2)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(7.6, result);
        }

        [TestMethod]
        public void Multiple5()
        {
            var tokens = new List<Token>
            {
                new SubtractToken(),
                new NumberToken(3),
                new AddToken(),
                new NumberToken(4)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Multiple6()
        {
            var tokens = new List<Token>
            {
                new SubtractToken(),
                new NumberToken(3),
                new SubtractToken(),
                new NumberToken(4)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(-7, result);
        }

        [TestMethod]
        public void MultipleParenthesisedExpressions()
        {
            var tokens = new List<Token>
            {
                new NumberToken(3),
                new AddToken(),
                new OpenParenthesisToken(),
                new NumberToken(4),
                new MultiplyToken(),
                new OpenParenthesisToken(),
                new NumberToken(3),
                new CloseParenthesisToken(),
                new CloseParenthesisToken()
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid()
        {
            var tokens = new List<Token>
            {
                new MultiplyToken()
            };

            new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid2()
        {
            var tokens = new List<Token>
            {
                new NumberToken(54),
                new MultiplyToken()
            };

            new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid3()
        {
            var tokens = new List<Token>
            {
                new NumberToken(54),
                new MultiplyToken(),
                new NumberToken(5),
                new MultiplyToken()
            };

            new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid4()
        {
            var tokens = new List<Token>
            {
                new NumberToken(54),
                new MultiplyToken(),
                new SubtractToken()
            };

            new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid5()
        {
            var tokens = new List<Token>
            {
                new OpenParenthesisToken(),
                new NumberToken(3.3)
            };

            new Parser(tokens).Parse();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            var tokens = new List<Token>
            {
                new NumberToken(4),
                new DivideToken(),
                new NumberToken(0)
            };

            new Parser(tokens).Parse();
        }
    }
}
