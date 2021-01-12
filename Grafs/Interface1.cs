using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Grafs
{
    class Shape
    {
        protected GraphicsPath figure;
        protected Graphics GSize;
        protected int x;
        protected int y;
        protected int size;
        protected int MyColor;
        protected Rectangle S;
        protected bool selected = false;
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
        }

        public virtual void changesize(int dsize)
        {
            size = size + dsize;
        }

        public virtual void RePaint(int value)
        {
            MyColor = value;
        }

        public virtual void CheckOut()
        {
            
        }
    }
}
