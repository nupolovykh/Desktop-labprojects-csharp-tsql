using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{

    public class BankAccount : ILocker<decimal, Person>
    {
        public decimal Value { get; set; }
        private bool isLocked;

        public BankAccount(decimal value)
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
