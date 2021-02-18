using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Grafs
{
    class CGroup:Shape
    {
        private int _maxcount;
        private int _count;
        Shape[] _shapes;
        
        public CGroup(int maxcount, RectangleF Rect)
        {
            code = "G";
            MyOutSize = Rect;
            _maxcount = maxcount;
            _count = 0;
            _shapes = new Shape[_maxcount];
            for (int i = 0; i < _maxcount; i++)
                _shapes[i] = null;
        }

        public bool addShape(Shape shape)
        {
            if (_count >= _maxcount)
                return false;
            shape.Set(true);
            _count++;
            _shapes[_count - 1] = shape;
            return true;
        }

        public override void Move(int dx, int dy)
        {
            for (int i = 0; i < _count; i++)
                _shapes[i].Move(dx, dy);
            CorrectOut();
        }

        public override void draw(Graphics e)
        {
            for (int i = 0; i < _count; i++)
                _shapes[i].draw(e);
        }

        public override void RePaint(int color)
        {
            for (int i = 0; i < _count; i++)
                _shapes[i].RePaint(color);
        }

        public override void changesize(int dsize)
        {
            for (int i = 0; i < _count; i++)
                _shapes[i].changesize(dsize);
        }
        public override void Update()
        {
            for (int i = 0; i < _count; i++)
                _shapes[i].Update();
        }
        protected override void Out_size()
        {
            if (!flag_in_group)
                while (!CheckOut())
                {
                    changesize(-1);
                }
        }
        public override bool CheckOut()
        {
            for (int i = 0; i < _count; i++)
            {
                if (!_shapes[i].CheckOut())
                {
                    figure = _shapes[i].getPath();
                    return false;
                }
            }
            return true;
        }
        public override void CorrectOut()
        {
            if (flag_in_group == false)
                while (!CheckOut())
                {
                    RectangleF Rec = figure.GetBounds();
                    PointF LeftTop = Rec.Location;
                    PointF RightTop = new PointF(Rec.Right, Rec.Top);
                    PointF LeftBottom = new PointF(Rec.Left, Rec.Bottom);
                    PointF RightBottom = new PointF(Rec.Right, Rec.Bottom);
                    if (!MyOutSize.Contains(LeftTop) && !MyOutSize.Contains(LeftBottom))
                        Move(1, 0);
                    if (!MyOutSize.Contains(LeftTop) && !MyOutSize.Contains(RightTop))
                        Move(0, 1);
                    if (!MyOutSize.Contains(RightTop) && !MyOutSize.Contains(RightBottom))
                        Move(-1, 0);
                    if (!MyOutSize.Contains(LeftBottom) && !MyOutSize.Contains(RightBottom))
                        Move(0, -1);
                }
            Update();
        }


        public override void Setselected(bool checkS)
        {
            for (int i = 0; i < _count; i++)
                _shapes[i].Setselected(checkS);
        }

        public override bool hit(int x, int y)
        {
            bool b = false;
            for (int i = 0; i < _count; i++)
                if (_shapes[i].hit(x, y))
                    b = true;
                    return b;
        }

        public override bool Select()
        {
            for (int i = 0; i < _count; i++)
                if (_shapes[i].Select())
                    return true;
            return false;
        }
    }
}
