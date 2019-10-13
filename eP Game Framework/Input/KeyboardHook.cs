using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ePGameFramework.Input
{
    public class KeyboardHook
    {
        [DllImport("User32.dll")]
        private static extern IntPtr SetWindowsHookExA(HookID hookID,KeyboardHookProc lpfn,IntPtr hmod,int dwThreadId);

        [DllImport("User32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hook,int code, IntPtr wParam, IntPtr lParam);

        public delegate IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam);

        private event KeyboardHookProc keyhookevent;

        private IntPtr hookPtr;

        public KeyboardHook()
        {
             this.keyhookevent += KeyboardHook_keyhookevent;
        }

        private IntPtr KeyboardHook_keyhookevent(int code, IntPtr wParam, IntPtr lParam)
        {
            KeyStaus ks = (KeyStaus)wParam.ToInt32();
            KeyboardHookStruct khs = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
            KeyEvent ke = ks == KeyStaus.KeyDown || ks == KeyStaus.SysKeyDown ? KeyDown : KeyUp;
            ke?.Invoke(this, new KeyEventArg()
            { 
                Key = khs.Key,
                KeyStaus = ks
            });
            return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

        public void ConfigHook()
        {
            hookPtr = SetWindowsHookExA(HookID.Keyboard_LL, keyhookevent,IntPtr.Zero,0);
            if (hookPtr == null)
                throw new Exception();
        }

        public delegate void KeyEvent(object sender, KeyEventArg e);

        public event KeyEvent KeyDown;

        public event KeyEvent KeyUp;
    }

    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public struct KeyboardHookStruct
    {
        [FieldOffset(0)]
        public Key Key;

        [FieldOffset(4)]
        public int ScanCode;

        [FieldOffset(8)]
        public int Flags;

        [FieldOffset(12)]
        public int Time;

        [FieldOffset(16)]
        public IntPtr dwExtraInfo;
    }

    public enum KeyStaus
    {
        KeyDown = 0x0100,
        KeyUp = 0x0101,
        SysKeyDown = 0x0104,
        SysKeyUp = 0x0105
    }

    public class KeyEventArg
    {
        public Key Key;

        public KeyStaus KeyStaus;


    }
}
