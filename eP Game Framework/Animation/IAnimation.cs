using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Animation
{
    public interface IAnimation
    {
        bool RunningAnimation(ref float value, double time);

        float getDuration();
    }
}
