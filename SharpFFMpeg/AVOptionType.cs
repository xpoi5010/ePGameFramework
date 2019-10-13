using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFFMpeg
{
    public enum AVOptionType
    {
        AV_OPT_TYPE_FLAGS,
        AV_OPT_TYPE_INT,
        AV_OPT_TYPE_INT64,
        AV_OPT_TYPE_DOUBLE,
        AV_OPT_TYPE_FLOAT,
        AV_OPT_TYPE_STRING,
        AV_OPT_TYPE_RATIONAL,
        AV_OPT_TYPE_BINARY,  ///< offset must point to a pointer immediately followed by an int for the length
        AV_OPT_TYPE_DICT,
        AV_OPT_TYPE_UINT64,
        AV_OPT_TYPE_CONST = 128,
        AV_OPT_TYPE_IMAGE_SIZE = 1397316165, ///< offset must point to two consecutive integers
        AV_OPT_TYPE_PIXEL_FMT = 1346784596,
        AV_OPT_TYPE_SAMPLE_FMT = 1397116244,
        AV_OPT_TYPE_VIDEO_RATE = 1448231252, ///< offset must point to AVRational
        AV_OPT_TYPE_DURATION = 1146442272,
        AV_OPT_TYPE_COLOR = 1129270354,
        AV_OPT_TYPE_CHANNEL_LAYOUT = 1128811585,
        AV_OPT_TYPE_BOOL = 1112493900,
    };
}
/*
 *  ((d) | ((c) << 8) | ((b) << 16) | ((uint)(a) << 24))
 */
