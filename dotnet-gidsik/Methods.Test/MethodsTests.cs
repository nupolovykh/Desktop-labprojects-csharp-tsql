namespace Methods.Test;

public class MethodsTests
{
    [Fact]
    public void RightExpressionFactDecode() {
        double[] array = {1,2,3,4,5};
        double answer = ArrayMethodsLibrary.FindMaximum(array);
        Assert.Equal(5, answer);
        answer = ArrayMethodsLibrary.FindMinimum(array);
        Assert.Equal(1, answer);
        answer = ArrayMethodsLibrary.FindAverage(array);
        Assert.Equal(3, answer);
        answer = ArrayMethodsLibrary.FindMedian(array);
        Assert.Equal(3, answer);
        answer = ArrayMethodsLibrary.FindGeometricAverage(array);
        Assert.Equal(2.605171084697352, answer);
        double[] array2 = { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue };
        answer = ArrayMethodsLibrary.FindAverage(array2);
        Assert.Equal(double.MaxValue, answer);
    }

    [Fact]
    public void ThrowsOnWrongExpression() {
        double[] nullarray = null;
        Action action = () => { ArrayMethodsLibrary.FindMaximum(nullarray); };
        Assert.ThrowsAny<ArgumentException>(action);
        double[] empty = {};
        action = () => { ArrayMethodsLibrary.FindMaximum(empty); };
        Assert.ThrowsAny<ArgumentException>(action);
    }
}