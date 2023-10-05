namespace Interface
{
    public interface ILocker<T, P>
    {
        T Value { get; set; }
        void LockEdit();
        void LockRead();
        void UnLock();
    }
}