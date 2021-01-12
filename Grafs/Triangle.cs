﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Grafs
{
    class Triangle: Shape
    {
        public Triangle(int _x, int _y, int height, int widht)
        {
            S = new Rectangle(0, 0, widht, height);
            figure = new GraphicsPath();
            MyColor = 1;
            x = _x;
            y = _y;
            size = 60;
        }


        public override void Update()
        {
            figure.Reset();
            Point[] points =
            {
                 new Point(x,  Convert.ToInt32(y-size*Math.Sqrt(3)/3)),
                 new Point(x-size/2, Convert.ToInt32(y+size*Math.Sqrt(3)/6)),
                 new Point(x+size/2,  Convert.ToInt32(y+size*Math.Sqrt(3)/6)),
             };
            figure.AddPolygon(points);
        }
    }
}
