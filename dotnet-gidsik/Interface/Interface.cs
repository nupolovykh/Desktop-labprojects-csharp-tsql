namespace Interface
{
    public interface ILocker<T, P>
    {
        T Data { get; set; }
        P Owner { get; set; }
        void LockEdit();
        void LockRead();
        void UnLock();
    }
}