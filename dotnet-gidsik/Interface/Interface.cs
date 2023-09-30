namespace Interface
{
    public interface ILocker<T>
    {
        T Value { get; set; }
        void LockEdit();
        void LockRead();
        void UnLock();
    }
}