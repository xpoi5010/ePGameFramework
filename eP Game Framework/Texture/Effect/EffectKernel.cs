using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Texture.Effect
{
    //3x3 kernel

    public abstract class EffectKernel
    {
        public const int KernelSize = 3;

        public const int StartValue = -(KernelSize >> 1);

        float[] BaseKernelContent = new float[KernelSize * KernelSize];
        /*
         * 0 1 2
         * 3 4 5
         * 6 7 8
         */
        public EffectKernel()
        {

        }

        public float this[int index]
        {
            get
            {
                return BaseKernelContent[index];
            }
            set
            {
                BaseKernelContent[index] = value;
            }
        }
        public float GetValue(int x,int y)
        {
            int newX = x - StartValue;
            int newY = y - StartValue;
            return BaseKernelContent[x + (y * KernelSize)];
        }

        public void SetValue(int x,int y,float Value)
        {
            int newX = x - StartValue;
            int newY = y - StartValue;
            BaseKernelContent[newX + (newY * KernelSize)] = Value;
        }

        public abstract void ApplyEffect();

        public float[] GetKernelArray()
        {
            return BaseKernelContent;
        }
    }

    
}
