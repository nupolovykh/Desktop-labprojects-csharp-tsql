namespace Interface
{
    public interface ILocker<T, P>
    {
        T Data { get; set; }
        void LockEdit();
        void LockRead();
        void UnLock();
    }
}