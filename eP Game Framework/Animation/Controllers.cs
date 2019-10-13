using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Animation
{
    public static class Controllers
    {
        public static readonly Controller<float> FloatController = floatControl;

        public static readonly Controller<int> IntController = intControl;

        private static void floatControl(ref float value,float newvalue)
        {
            value = newvalue;
        }

        private static void intControl(ref int value, float newvalue)
        {
            value = (int)newvalue;
        }
    }
}
