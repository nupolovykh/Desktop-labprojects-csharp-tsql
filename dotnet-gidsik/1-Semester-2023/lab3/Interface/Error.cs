namespace Interface;

public class ValueIsLockedException: Exception
{
    public ValueIsLockedException(string message): base(message)
    {
    }
}