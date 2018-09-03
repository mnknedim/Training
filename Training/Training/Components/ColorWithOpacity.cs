using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Training.Ex;

namespace Training.Components
{
    public class ColorWithOpacity : ExStackLayout
    {
        
        public ColorWithOpacity(Color color)
        {
            BackgroundColor = color;
            Opacity = 0.7;
        }
    }
}
