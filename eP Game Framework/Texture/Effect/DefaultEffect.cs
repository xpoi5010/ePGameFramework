using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Texture.Effect
{
    public class DefaultEffect : EffectKernel
    {
        public override void ApplyEffect()
        {
            this.SetValue(0, 0, 1);
        }
    }
}
