using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{

    public class BankAccount : ILocker<decimal, Person>
    {
        public decimal Data { get; set; }
        public bool isLocked = true;

        public BankAccount(decimal amout) => Data = amout;

        public void LockEdit() => isLocked = true;
        public void LockRead() => isLocked = true;
        public void UnLock() => isLocked = false;
    }
}
