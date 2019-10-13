using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFFMpeg
{
    public struct AVClass
    {
        public delegate string item_name_del(ref object ctx);

        public string class_name;

        public item_name_del item_name;

        public AVOption option;

        public int version;

        public int log_level_offset_offset;

        public int parent_log_context_offset;

        public delegate object child_next_del(ref object obj, ref object prev);

        public child_next_del child_next;

        public delegate AVClass child_class_next_del(ref AVClass prev);

        public child_class_next_del child_class_next;

        public AVClassCategory category;

        public delegate AVClassCategory get_category_del(ref object ctx);

        public get_category_del get_category;

        public delegate int query_ranges_del(AVOptionRanges[] arr,object obj,string key,int flages);


    }
}
