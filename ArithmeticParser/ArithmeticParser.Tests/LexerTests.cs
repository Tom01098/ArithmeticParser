using ArithmeticParser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void OpenParenthesis()
        {
            var tokens = new Lexer().Lex("(");

            Assert.IsInstanceOfType(tokens[0], typeof(OpenParenthesisToken));
        }

        [TestMethod]
        public void CloseParenthesis()
        {
            var tokens = new Lexer().Lex(")");

            Assert.IsInstanceOfType(tokens[0], typeof(CloseParenthesisToken));
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
        public void Multiple()
        {
            var tokens = new Lexer().Lex("*");

            Assert.IsInstanceOfType(tokens[0], typeof(MultiplyToken));
        }
    }
}
