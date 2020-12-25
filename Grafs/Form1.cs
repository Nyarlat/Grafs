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
                st.getObj(i).draw(e.Graphics);
            }
        }

        bool check;
        private void pb1_MouseClick(object sender, MouseEventArgs e)
        {
            if(cb1.Checked == true) { 
            st.add(new CCircle(e.X, e.Y));
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
        Pen Mypen;

        public CCircle(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void draw(Graphics e)
        {
            if (selected == false)
            {
                Mypen = new Pen(Color.Black, 3);
            }
            else
            {
                Mypen = new Pen(Color.Red, 3);
            }
            e.DrawEllipse(Mypen, (x - radius), (y - radius), 2 * radius, 2 * radius);
        }

        public bool Select()
        {
            return selected;
        }

        public void Setselected(bool checkS)
        {
            selected = checkS;
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
