using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Control
{
    public interface IControl
    {
        void Draw();

        bool MouseInput();
        
    }
}
