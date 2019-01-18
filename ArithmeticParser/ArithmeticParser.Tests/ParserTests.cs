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
        public void SingleInteger()
        {
            var tokens = new List<Token>
            {
                new NumberToken(3)
            };

            var result = new Parser(tokens).Parse();

            Assert.AreEqual(3, result);
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
    }
}
