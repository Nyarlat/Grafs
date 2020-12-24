using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafs
{
    public partial class Form1 : Form
    {
        MyStorage st = new MyStorage(100);
        public Form1()
        {
            InitializeComponent();
        }

        

        private void pb1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < st.count; i++)
            {
                st.getObj(i).draw(e);
            }
        }

        bool check ;
        private void pb1_MouseClick(object sender, MouseEventArgs e)
        {
            if(cb1.Checked == true) { 
            st.add(new CCircle(e));
            pb1.Invalidate();
            }
            else
            {
                bool one = true;
                for (int i = st.count-1; i >= 0; i--)
                {
                    if (check == false)
                        st.getObj(i).Setselected(false);
                    if (st.getObj(i).hit(e) && one == true)
                    {
                        one = false;
                        st.getObj(i).Setselected(true);
                    }
                }
                pb1.Invalidate();
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                check = true;
            }
            if(e.KeyCode == Keys.Delete)
            {
                int amount = st.count;
                for (int i = 0, j=0; i < amount; i++, j++)
                {
                    if(st.getObj(j).Select())
                    {
                        st.del(j);
                        j--;
                    }
                    pb1.Invalidate();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            check = false;
        }
    }

    class CCircle
    {
        public int x;
        public int y;
        public int radius = 30;
        public bool selected = false;

        public CCircle(MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        public void draw(PaintEventArgs e)
        {
            if(selected == false)
                e.Graphics.DrawEllipse(new Pen(Brushes.Black, 3), (x - radius), (y - radius), 2 * radius, 2 * radius);
            else
                e.Graphics.DrawEllipse(new Pen(Brushes.Red, 3), (x - radius), (y - radius), 2 * radius, 2 * radius);
        }

        public bool Select()
        {
            return selected;
        }

        public void Setselected(bool check)
        {
            selected = check;
        }

        public bool hit(MouseEventArgs e) {
            if (Math.Sqrt((e.X - x)*(e.X - x) + (e.Y - y)*(e.Y - y)) <= 30)
                return true;
            return false;
        }
    }
    class MyStorage
    {
        public CCircle[] objects;
        public int count;
        public int size;
        public MyStorage(int _size)
        {
            size = _size;
            objects = new CCircle[_size];
            count = 0;
        }
        public int getSize()
        {
            return size;
        }
        public void add(CCircle NewObj)
        {
            objects[count] = NewObj;
            count++;
        }
        public void del(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                objects[i] = objects[i + 1];
            }
            count--;
        }
        public CCircle getObj(int index)
        {
            return objects[index];
        }
    }
}
