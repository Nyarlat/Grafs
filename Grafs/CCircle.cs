using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Grafs
{
    class CCircle:Shape
    {
        public CCircle()
        {
            code = "C";
        }
        public CCircle(int _x, int _y,RectangleF Rect)
        {
            code = "C";
            MyOutSize = Rect;
            figure = new GraphicsPath();
            MyColor = 1;
            x = _x;
            y = _y;
            size = 30;
            Update();
            CorrectOut();
        }

        public override void Update()
        {
            figure.Reset();
            figure.AddEllipse((x - size), (y - size), 2 * size, 2 * size);
        }


    }
}
