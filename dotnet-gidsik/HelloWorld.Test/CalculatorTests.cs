namespace HelloWorld.Test

{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("(")]
        [InlineData("()")]
        [InlineData("(1)")]
        [InlineData("(143243)")]
        [InlineData("(1 + 3)")]
        [InlineData("(1+(0-3))-")]
        [InlineData("-(1+(0-3))")]
        [InlineData("(-4)*(2+5)*(3-2)")]
        public void ThrowsOnWrongExpression(string input)
        {
            Action action = () => { Calculator.Tests(input); };
            Assert.ThrowsAny<ArgumentException>(action);
        }

        [Theory]
        [InlineData("1 3 +", "(1+3)")]
        public void RightExpressionDijkstra(string expected, string input) {
            string answer = Calculator.Dijkstra(input);
            Assert.Equal(expected, answer);
        }

        [Fact]
        public void RightExpressionFactDecode() {
            double answer = Calculator.Decode("1 3 +");
            Assert.Equal(4, answer);
        }
    }
}