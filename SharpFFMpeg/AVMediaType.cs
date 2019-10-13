using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFFMpeg
{
    public enum AVMediaType
    {
        Unknown= -1,  ///< Usually treated as AVMEDIA_TYPE_DATA
        Video,
        Audio,
        Data,          ///< Opaque data information usually continuous
        Subtitle,
        Attachment,    ///< Opaque data information usually sparse
        NB
    };
}
