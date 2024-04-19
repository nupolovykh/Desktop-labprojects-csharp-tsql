using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{

    public class BankAccount : ILocker<decimal>
    {
        public decimal Data { get; set; }
        public string Info { get; set; }
        public bool isLockedR = true;
        public bool isLockedE  = true;
        public void LockEdit() => isLockedE = true;
        public void LockRead() => isLockedR = true;
        public void UnLock(){
            isLockedE = false;
            isLockedR = false;
        }
    }
}
