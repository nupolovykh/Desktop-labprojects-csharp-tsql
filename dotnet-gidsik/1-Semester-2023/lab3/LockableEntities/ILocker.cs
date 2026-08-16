namespace Interface
{
    public interface ILocker<T>
    {
        T Data { get; set; }
        void LockEdit();
        void LockRead();
        void UnLock();
    }
}