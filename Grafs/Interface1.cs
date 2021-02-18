using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Grafs
{
    public class Shape
    {
        public string code;
        protected int x;
        protected int y;
        protected int size;
        protected int MyColor;
        protected RectangleF MyOutSize;
        protected bool selected = false;
        protected bool flag_in_group=false;
        protected GraphicsPath figure = new GraphicsPath();
        Pen Mypen;
        virtual public void draw(Graphics e) {
            if (selected == true)
            {
                Mypen = new Pen(Color.Red, 3);
            }
            else
            {
                if (MyColor==1)
                    Mypen = new Pen(Color.Black, 3);
                else if (MyColor==2)
                    Mypen = new Pen(Color.Green, 3);
                else
                    Mypen = new Pen(Color.Blue, 3);
            }
            Update();
            e.DrawPath(Mypen, figure);
        }
        virtual public bool Select() { return selected; }
        virtual public void Setselected(bool checkS) {
            selected = checkS;
        }
        public virtual bool hit(int x, int y)
        {
            Update();
            return figure.IsVisible(x, y);
        }
        public virtual void Update() { }
        public virtual void Move(int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
            Update();
            if (!flag_in_group)
                CorrectOut();
        }
        public void Set(bool f)
        {
            flag_in_group = f;
        }
    

        public virtual void changesize(int dsize)
        {
            size = size + dsize;
            Update();
            if (!flag_in_group)
                Out_size();
        }

        public virtual void RePaint(int value)
        {
            MyColor = value;
        }

        public virtual bool CheckOut()
        {
            return MyOutSize.Contains(figure.GetBounds());
        }
        virtual protected void Out_size()
        {
            while (!CheckOut())
            {
                changesize(-1);
            }
        }

        public virtual void CorrectOut()
        {
            while (!CheckOut())
            {
                RectangleF shape = figure.GetBounds();
                PointF LeftTop = shape.Location;
                PointF RightTop = new PointF(shape.Right, shape.Top);
                PointF LeftBottom = new PointF(shape.Left, shape.Bottom);
                PointF RightBottom = new PointF(shape.Right, shape.Bottom);
                if (!MyOutSize.Contains(LeftTop) && !MyOutSize.Contains(LeftBottom))
                {
                    ++x;
                }
                if (!MyOutSize.Contains(LeftTop) && !MyOutSize.Contains(RightTop))
                {
                    ++y;
                }
                if (!MyOutSize.Contains(RightTop) && !MyOutSize.Contains(RightBottom))
                {
                    --x;
                }
                if (!MyOutSize.Contains(LeftBottom) && !MyOutSize.Contains(RightBottom))
                {
                    --y;
                }
                Update();
            }        
        }
        virtual public GraphicsPath getPath()
        {
            return figure;
        }
        public virtual string GetName()
        {
            return code;
        }
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(code);
            writer.WriteLine(size.ToString() + ' ' + x.ToString() + ' ' + y.ToString() + ' ' + MyColor.ToString());
            writer.WriteLine(MyOutSize.X.ToString() + ' ' + MyOutSize.Y.ToString() + ' ' + MyOutSize.Width.ToString() + ' ' + MyOutSize.Height.ToString());
        }
        public virtual void Load(StreamReader reader)
        {
            code = GetName();
            string[] s = reader.ReadLine().Split(' ');
            size = Convert.ToInt32(s[0]);
            x = Convert.ToInt32(s[1]);
            y = Convert.ToInt32(s[2]);
            MyColor = Convert.ToInt32(s[3]);
            string[] a = reader.ReadLine().Split(' ');
            MyOutSize.X = Convert.ToInt32(a[0]);
            MyOutSize.Y = Convert.ToInt32(a[1]);
            MyOutSize.Width = Convert.ToInt32(a[2]);
            MyOutSize.Height = Convert.ToInt32(a[3]);
        }
    }
}
