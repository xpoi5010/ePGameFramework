using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFFMpeg
{
    public enum AVSampleFormat
    {
        None = -1,
        U8,          ///< unsigned 8 bits
        S16,         ///< signed 16 bits
        S32,         ///< signed 32 bits
        FLT,         ///< float
        DBL,         ///< double

        U8P,         ///< unsigned 8 bits, planar
        S16P,        ///< signed 16 bits, planar
        S32P,        ///< signed 32 bits, planar
        FLTP,        ///< float, planar
        DBLP,        ///< double, planar
        S64,         ///< signed 64 bits
        S64P,        ///< signed 64 bits, planar

        AV_SAMPLE_FMT_NB           ///< Number of sample formats. DO NOT USE if linking dynamically
    }
}
