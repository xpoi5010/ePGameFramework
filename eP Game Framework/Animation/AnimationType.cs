using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Animation
{
    public class AnimationType<T>
    {
        public T BaseObject;

        public Controller<T> ValueController { get; set; }

        public ValueConverter<T> ValueConverter { get; set; }

        public List<IAnimation> Animations = new List<IAnimation>();

        //private DateTime baseTime;

        private DateTime baseTime;

        public static implicit operator T(AnimationType<T> animation)
        {
            return animation.BaseObject;
        }

        public static implicit operator AnimationType<T>(T baseItem)
        {
            return new AnimationType<T>(baseItem);
        }

        

        public AnimationType(T baseItem)
        {
            BaseObject = baseItem;
        }

        public AnimationType()
        {
            
        }

        private void ResetTime()
        {
            baseTime = DateTime.Now;
        }

        public void BeginAnimation(float duration,float StartValue,float EndValue, Easing easing)
        {
            ResetTime();
            Animation animation = new Animation
            {
                StartValue = StartValue,
                EndValue=EndValue,
                Easing = easing,
                Duration = duration
            };
            Animations.Add(animation);
        }

        public void BeginAnimation(IAnimation animation)
        {
            ResetTime();
            Animations.Clear();
            Animations.Add(animation);
        }

        public void LoadAnimation(IAnimation animation)
        {
            if (Animations.Count == 0)
                ResetTime();
            Animations.Add(animation);
        }
        public void BeginAnimation(float duration, float EndValue, Easing easing)
        {
            ResetTime();
            Animations.Clear();
            Animation animation = new Animation
            {
                StartValue = ValueConverter(BaseObject),
                EndValue = EndValue,
                Easing = easing,
                Duration = duration
            };
            Animations.Add(animation);
        }

        public void Delay(float time)
        {
            if (Animations.Count == 0)
                ResetTime();
            Delay delay = new Delay(time);
            Animations.Add(delay);
        }

        public void BeginDelay(float time)
        {
            ResetTime();
            Animations.Clear();
            Delay delay = new Delay(time);
            Animations.Add(delay);
        }
        public void LoadAnimation(float duration, float StartValue, float EndValue, Easing easing)
        {
            if (Animations.Count == 0)
                ResetTime();
            Animation animation = new Animation
            {
                StartValue = StartValue,
                EndValue = EndValue,
                Easing = easing,
                Duration = duration
            };
            Animations.Add(animation);
        }

        public void LoadAnimation(float duration, float EndValue, Easing easing)
        {
            if (duration == 0)
                throw new Exception("duration can't be zero.");
            if (Animations.Count == 0)
                ResetTime();
            Animation animation = new Animation
            {
                StartValue = ValueConverter(BaseObject),
                EndValue = EndValue,
                Easing = easing,
                Duration = duration
            };
            Animations.Add(animation);
        }

        public void RunningAnimation(DateTime current)
        {
        funcBase:
            {
                if (Animations.Count == 0)
                    return;
                TimeSpan ts = current - baseTime;
                float f = ValueConverter(BaseObject);
                bool Running = Animations[0].RunningAnimation(ref f, ts.TotalMilliseconds);
                ValueController(ref BaseObject, f);
                if (!Running)
                {
                    baseTime = baseTime.AddMilliseconds(Animations[0].getDuration());
                    Animations[0].RunningAnimation(ref f, Animations[0].getDuration());
                    ValueController(ref BaseObject, f);
                    Animations.RemoveAt(0);
                    goto funcBase;
                }
            }
        }

        public void ChangeBaseTime(DateTime baseTime)
        {
            this.baseTime = baseTime;
        }

        public void ClearAllAnimation()
        {
            Animations.Clear();
        }
    }

    public delegate void Controller<T>(ref T type, float newValue);

    public delegate float ValueConverter<T>(T source);
}
