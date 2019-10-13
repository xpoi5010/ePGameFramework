using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ePGameFramework.Animation
{
    public class LoopEndlessAnimation:IAnimation
    {
        private List<IAnimation> Animations = new List<IAnimation>();

        private int BaseInt = 0;

        public float getDuration()
        {
            throw new Exception();
        }

        double baseTime = 0;
        public bool RunningAnimation(ref float value, double time)
        {
            if (Animations.Count == 0)
                return true;
        funcBase:
            {
                if (BaseInt >= Animations.Count)
                {
                    BaseInt = 0;
                }
                double ntime = time - baseTime;
                bool Running = Animations[BaseInt].RunningAnimation(ref value, ntime);
                if (!Running)
                {
                    baseTime = baseTime + (Animations[BaseInt].getDuration());
                    float dur = Animations[BaseInt].getDuration();
                    Animations[BaseInt].RunningAnimation(ref value, dur);
                    BaseInt++;
                    goto funcBase;
                }
            }
            return true;
        }

        public void Add(IAnimation animation)
        {
            Animations.Add(animation);
        }
    }
}
