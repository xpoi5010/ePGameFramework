﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ePGameFramework.Animation
{
    /*
     * Source Code:https://github.com/ai/easings.net/blob/master/src/easings/easingsFunctions.ts
     * Thanks easings.net for opening source.
     */
    public delegate double Easing(double t);

    public static class Easings
    {
        const double PI = Math.PI;
        const double c1 = 1.70158;
        const double c2 = c1 * 1.525;
        const double c3 = c1 + 1;
        const double c4 = (2 * PI) / 3;
        const double c5 = (2 * PI) / 4.5;

        public static readonly Easing BounceOut = x =>
        {
            const double n1 = 7.5625;
            const double d1 = 2.75;
            if (x < 1 / d1)
            {
                return n1 * x * x;
            }
            else if (x < 2 / d1)
            {
                return n1 * (x -= (1.5 / d1)) * x + .75;
            }
            else if (x < 2.5 / d1)
            {
                return n1 * (x -= (2.25 / d1)) * x + .9375;
            }
            else
            {
                return n1 * (x -= (2.625 / d1)) * x + .984375;
            }
        };

        public static readonly Easing Linear = x => x;

        public static readonly Easing EaseInQuad = x =>
        {
            return x * x;
        };

        public static readonly Easing EaseOutQuad = x =>
        {
            return 1 - (1 - x) * (1 - x);
        };

        public static readonly Easing EaseInOutQuad = x =>
        {
            return x < 0.5 ?
            2 * x * x :
            1 - Math.Pow(-2 * x + 2, 2) / 2;
        };

        public static readonly Easing EaseInCubic = x =>
        {
            return x * x * x;
        };

        public static readonly Easing EaseOutCubic = x =>
        {
            return 1 - Math.Pow(1 - x, 3);
        };

        public static readonly Easing EaseInOutCubic = x =>
        {
            return x < 0.5 ?
            4 * x * x * x :
            1 - Math.Pow(-2 * x + 2, 3) / 2;
        };

        public static readonly Easing EaseInQuart = x =>
        {
            return x * x * x * x;
        };

        public static readonly Easing EaseOutQuart = x =>
        {
            return 1 - Math.Pow(1 - x, 4);
        };

        public static readonly Easing EaseInOutQuart = x =>
        {
            return x < 0.5 ?
             8 * x * x * x * x :
             1 - Math.Pow(-2 * x + 2, 4) / 2;
        };

        public static readonly Easing EaseInQuint = x =>
        {
            return x * x * x * x * x;
        };

        public static readonly Easing EaseOutQuint = x =>
        {
            return 1 - Math.Pow(1 - x, 5);
        };

        public static readonly Easing EaseInOutQuint = x => 
        {
            return x < 0.5 ?
                16 * x * x * x * x * x :
                1 - Math.Pow(-2 * x + 2, 5) / 2;
        };
        public static readonly Easing EaseInSine = x => 
        {
            return 1 - Math.Cos(x * PI / 2);
        };
        public static readonly Easing EaseOutSine = x => 
        {
            return Math.Sin(x * PI / 2);
        };
        public static readonly Easing EaseInOutSine = x => 
        {
            return -(Math.Cos(PI * x) - 1) / 2;
        };
        public static readonly Easing EaseInExpo = x => 
        {
            return x == 0 ? 0 : Math.Pow(2, 10 * x - 10);
        };
        public static readonly Easing EaseOutExpo = x => 
        {
            return x == 1 ? 1 : 1 - Math.Pow(2, -10 * x);
        };
        public static readonly Easing EaseInOutExpo = x => 
        {
            return x == 0 ? 0 : x == 1 ? 1 : x < 0.5 ?
                Math.Pow(2, 20 * x - 10) / 2 :
                (2 - Math.Pow(2, -20 * x + 10)) / 2;
        };
        public static readonly Easing EaseInCirc = x => 
        {
            return 1 - Math.Sqrt(1 - Math.Pow(x, 2));
        };
        public static readonly Easing EaseOutCirc = x =>
        {
            return Math.Sqrt(1 - Math.Pow(x - 1, 2));
        };
        public static readonly Easing EaseInOutCirc = x => 
        {
            return x < 0.5 ?
                (1 - Math.Sqrt(1 - Math.Pow(2 * x, 2))) / 2 :
                (Math.Sqrt(1 - Math.Pow(-2 * x + 2, 2)) + 1) / 2;
        };
        public static readonly Easing EaseInBack = x => 
        {
            return c3 * x * x * x - c1 * x * x;
        };
        public static readonly Easing EaseOutBack = x => 
        {
            return 1 + c3 * Math.Pow(x - 1, 3) + c1 * Math.Pow(x - 1, 2);
        };
        public static readonly Easing EaseInOutBack = x => 
        {
            return x < 0.5 ?
                (Math.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2 :
                (Math.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        };
        public static readonly Easing EaseInElastic = x => 
        {
            return x == 0 ? 0 : x == 1 ? 1 :
                -Math.Pow(2, 10 * x - 10) * Math.Sin((x * 10 - 10.75) * c4);
        };
        public static readonly Easing EaseOutElastic = x => 
        {
            return x == 0 ? 0 : x == 1 ? 1 :
                Math.Pow(2, -10 * x) * Math.Sin((x * 10 - 0.75) * c4) + 1;
        };
        public static readonly Easing EaseInOutElastic = x => 
        {
            return x == 0 ? 0 : x == 1 ? 1 : x < 0.5 ?
                -(Math.Pow(2, 20 * x - 10) * Math.Sin((20 * x - 11.125) * c5)) / 2 :
                Math.Pow(2, -20 * x + 10) * Math.Sin((20 * x - 11.125) * c5) / 2 + 1;
        };
        public static readonly Easing EaseInBounce = x => 
        {
            return 1 - BounceOut(1 - x);
        };

    }
}
