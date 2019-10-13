using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Animation
{
    public class Delay:IAnimation
    {
        public float DelayTime { get; set; }

        public Delay(float DelayTime)
        {
            this.DelayTime = DelayTime;
        }

        public bool RunningAnimation(ref float value, double CurrentTime)
        {
            return (CurrentTime <= DelayTime);
        }

        public float getDuration()
        {
            return DelayTime;
        }
    }
}
