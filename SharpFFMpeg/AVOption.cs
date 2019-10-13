using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SharpFFMpeg
{

    [StructLayout(LayoutKind.Explicit,Size =56 )]
    public unsafe struct AVOption
    {
        [FieldOffset(0)]
        public ManagedString64 name;//8

        [FieldOffset(8)]
        public ManagedString64 help;//8

        [FieldOffset(16)]
        public int offset;//4

        [FieldOffset(20)]
        public AVOptionType type;//4

        [FieldOffset(24)]
        public long i64;//8

        [FieldOffset(24)]
        public double dbl;//8

        [FieldOffset(24)]
        public ManagedString64 str;//8

        [FieldOffset(24)]
        public AVRational q;//8

        [FieldOffset(32)]
        public double min;//8

        [FieldOffset(40)]
        public double max;//8

        [FieldOffset(48)]
        public int flags;//4

        [FieldOffset(52)]
        public ManagedString64 unit;
    }

    [StructLayout(LayoutKind.Explicit,Size =8)]
    public struct ManagedString64
    {
        [FieldOffset(0)]
        public IntPtr Pointer;

        public string getBaseString()
        {
            return Marshal.PtrToStringUni(Pointer);
        }

        public static implicit operator String(ManagedString64 value)
        {
            return value.getBaseString();
        }
    }
}
