using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Draw_08CXH_6
{
    abstract class Geometry : IGeometry
    {

        public virtual string ToString(int I)
        {
            return string.Empty;
        }

        public virtual void DrawToCanvas(Canvas can)
        {

        }
    }
}
