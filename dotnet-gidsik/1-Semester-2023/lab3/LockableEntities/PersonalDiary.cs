using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface;

public class PersonalDiary : ILocker<string>
{
    public string Data {get; set;}
    public bool isLockedR = true;
    public bool isLockedE  = true;
    public void LockEdit() => isLockedE = true;
    public void LockRead() => isLockedR = true;
    public void UnLock(){
        isLockedE = false;
        isLockedR = false;
    }
}
