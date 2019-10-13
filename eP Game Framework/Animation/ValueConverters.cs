using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Animation
{
    public static class ValueConverters
    {
        public static readonly ValueConverter<float> FloatConverter = floatConverter;

        public static readonly ValueConverter<int> IntConverter = intConverter;

        public static readonly ValueConverter<string> TypewriterConverter = typewriterConverter;

        private static float floatConverter(float obj)
        {
            return obj;
        }

        private static float intConverter(int obj)
        {
            return obj;
        }

        private static float typewriterConverter(string obj)
        {
            return obj.Length;
        }
    }
}
