using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Input
{
    public enum HookID
    {
        Callwndproc = 4,
        Callwndprocert=12,
        Cbt=5,
        Debug=9,
        Foregroundidle=11,
        GetMessage=3,
        JournalPlayback=1,
        JournalRecord=0,
        Keyboard = 2,
        Keyboard_LL = 13,
        Mouse = 7,
        MouseLL = 14,
        MsgFilter = -1,
        Shell = 10,
        SysmsgFilter = 6
    }
}
