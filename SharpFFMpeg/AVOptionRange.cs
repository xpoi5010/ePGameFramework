using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFFMpeg
{
    public struct AVOptionRange
    {
        public string str;

        public double value_min;

        public double value_max;

        public double component_min;

        public double component_max;

        public int is_range;
    }

    public struct AVOptionRanges
    {
        public AVOptionRange[] range;

        public int nb_ranges;

        public int nb_components;
    }
}
