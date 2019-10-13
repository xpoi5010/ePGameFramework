using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Animation
{
    public class Animation : IAnimation
    {
		public float Duration { get; set; }

		public float StartValue { get; set; }

        public float EndValue { get; set; }

        public Easing Easing { get; set; }

        public bool RunningAnimation(ref float value, double time)
        {
            /*
            if (Duration == 0)
                throw new Exception("Duration cannot be zero.");
                */
            if (Duration < time)
                return false;
            if (Easing is null)
                Easing = Easings.Linear;
            float deltaValue = EndValue - StartValue;
            double t = time/Duration;
            t = Easing(t);
            deltaValue *= (float)t;
            value = deltaValue + StartValue;
            return true;
        }

		public Animation()
        {

        }

		public Animation(float duration, float StartValue, float EndValue, Easing easing)
        {
            this.StartValue = StartValue;
            this.EndValue = EndValue;
            this.Easing = easing;
            this.Duration = duration;
        }

        public float getDuration()
        {
            return Duration;
        }
    }
}
