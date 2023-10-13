using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface;

public class PersonalDiary : ILocker<string, Person>
{
    public string Data { get; set; }
    public Person Owner { get; set; }
    public bool isLocked;

    public void LockEdit() => isLocked = true;
    public void LockRead() => isLocked = true;
    public void UnLock() => isLocked = false;
}
