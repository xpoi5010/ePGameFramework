using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SharpFFMpeg
{
    

    public class AVCodec
    {
        const string DLLName = "";

        public string name;

        public string longName;

        public AVMediaType type;

        public AVCodecID id;

        public int capabilities;

        public AVRational[] supported_framerates;

        public AVPixelFormat pix_fmts;

        public int[] supported_samplerates;

        public AVSampleFormat sample_fmts;

        public ulong[] channel_layouts;

        public byte maxLowres;

        public AVClass priv_class;

        public AVProfile[] profiles;

        public int priv_data_size;

        public AVCodec next;

        public AVCodecDefault defaults;
    }
}
