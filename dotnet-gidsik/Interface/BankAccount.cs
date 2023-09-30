using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{

    public class BankAccount<T> : ILocker<T>
    {
        public T Value { get; set; }
        private bool isLocked;

        public BankAccount(T value)
        {
            Value = value;
        }


        public void LockEdit()
        {
            isLocked = true;
        }

        public void LockRead()
        {
            isLocked = true;
        }

        public void UnLock()
        {
            isLocked = false;
        }
    }
}
