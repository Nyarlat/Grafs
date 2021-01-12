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
        public CCircle(int _x, int _y, int height, int widht)
        {
            S = new Rectangle(0, 0, widht, height);
            figure = new GraphicsPath();
            MyColor = 1;
            x = _x;
            y = _y;
            size = 30;
        }

        public override void Update()
        {
            figure.Reset();
            figure.AddEllipse((x - size), (y - size), 2 * size, 2 * size);
        }


    }
}
