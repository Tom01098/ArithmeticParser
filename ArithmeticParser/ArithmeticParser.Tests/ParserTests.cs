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
                new IntegerToken(3)
            };

            int result = new Parser().Parse(tokens);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(54),
                new AddToken(),
                new IntegerToken(2)
            };

            int result = new Parser().Parse(tokens);

            Assert.AreEqual(56, result);
        }

        [TestMethod]
        public void Subtract()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(54),
                new SubtractToken(),
                new IntegerToken(2)
            };

            int result = new Parser().Parse(tokens);

            Assert.AreEqual(52, result);
        }

        [TestMethod]
        public void Multiply()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(3),
                new MultiplyToken(),
                new IntegerToken(2)
            };

            int result = new Parser().Parse(tokens);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Multiple()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(54),
                new SubtractToken(),
                new IntegerToken(52),
                new MultiplyToken(),
                new IntegerToken(4)
            };

            int result = new Parser().Parse(tokens);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Multiple2()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(54),
                new AddToken(),
                new IntegerToken(2),
                new AddToken(),
                new IntegerToken(5)
            };

            int result = new Parser().Parse(tokens);

            Assert.AreEqual(61, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid()
        {
            var tokens = new List<Token>
            {
                new MultiplyToken()
            };

            new Parser().Parse(tokens);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid2()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(54),
                new MultiplyToken()
            };

            new Parser().Parse(tokens);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid3()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(54),
                new MultiplyToken(),
                new IntegerToken(5),
                new MultiplyToken()
            };

            new Parser().Parse(tokens);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid4()
        {
            var tokens = new List<Token>
            {
                new IntegerToken(54),
                new MultiplyToken(),
                new SubtractToken()
            };

            new Parser().Parse(tokens);
        }
    }
}
