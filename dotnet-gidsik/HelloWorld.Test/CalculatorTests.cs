namespace HelloWorld.Test


{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("(")]
        [InlineData("(1 + 3)")]
        [InlineData("(1+(-3))")]
        //[InlineData("(-2+5)*(3-2)")]
        public void ThrowsOnWrongExpression(string input)
        {
            //if (Calculator.Dijkstra(input) == ("1 3 +")) Assert.

            Action action = () => { Calculator.Dijkstra(input); };
            Assert.ThrowsAny<ArgumentException>(action);
        }

        [Theory]
        [InlineData("1 3 +", "(1+3)")]
        public void RightExpression(string expected, string input) {
            string answer = Calculator.Dijkstra(input);
            Assert.Equal(expected, answer);
        }
    }
}