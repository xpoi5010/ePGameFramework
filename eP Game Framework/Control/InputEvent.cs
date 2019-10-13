using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Control
{
    public class MouseInputArgs
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool LeftButtonClicked { get; set; }

        public bool RightButtonClicked { get; set; }

        public bool ButtonClicked => LeftButtonClicked || RightButtonClicked;



    }
}
