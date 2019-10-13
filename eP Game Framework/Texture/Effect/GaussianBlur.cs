using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Texture.Effect
{
    public class GaussianBlur : EffectKernel
    {
        public float Sigma { get; set; } = 1;
        public override void ApplyEffect()
        {
            float totalC = 0;
            for (int x = StartValue; x <= -StartValue; x++)
                for (int y = StartValue; y <= -StartValue; y++)
                {
                    float value = (float)(1 / (2 * Math.PI * Math.Pow(Sigma, 2)) * Math.Exp(-(Math.Pow(x, 2) + Math.Pow(y, 2)) / (2 * Math.Pow(Sigma, 2))));
                    base.SetValue(x, y, value);
                    totalC += value;
                }
            for (int i = 0; i < 9; i++)
                base[i] *= (1 / totalC);
        }
    }
}
