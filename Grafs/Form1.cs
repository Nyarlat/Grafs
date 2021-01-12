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
        MyStorage<Shape> st = new MyStorage<Shape>(100);
        Bitmap bm;
        Graphics Paper;
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pb1.Width - 1, pb1.Height - 1);
            Paper = Graphics.FromImage(bm);
            pb1.Image = bm;
        }

        private void pb1_Paint(object sender, PaintEventArgs e)
        {
            Paper.Clear(Color.Ivory);
            for (int i = 0; i < st.count; i++)
            {
                st.getObj(i).draw(Paper);
            }
            pb1.Image = bm;
        }

        bool check;
        private void pb1_MouseClick(object sender, MouseEventArgs e)
        {
            if(cb1.Checked == true) {
                if (rdCircle.Checked)
                st.add(new CCircle(e.X, e.Y, pb1.Width, pb1.Height));
                else if (rdSquare.Checked)
                st.add(new Square(e.X, e.Y, pb1.Width, pb1.Height));
                else
                st.add(new Triangle(e.X, e.Y, pb1.Width, pb1.Height));
                pb1.Invalidate();
            }
            else
            {
                bool one = true;
                for (int i = st.count-1; i >= 0; i--)
                {
                    if (check == false)
                        st.getObj(i).Setselected(false);
                    if (st.getObj(i).hit(e.X, e.Y) && one == true)
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


            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < st.count; i++)
                {
                    if (st.getObj(i).Select())
                    {
                        st.getObj(i).Move(0, -1);
                        st.getObj(i).Update();
                    }
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                for (int i = 0; i < st.count; i++)
                {
                    if (st.getObj(i).Select())
                    {
                        st.getObj(i).Move(0, 1);
                        st.getObj(i).Update();
                    }
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < st.count; i++)
                {
                    if (st.getObj(i).Select())
                    {
                        st.getObj(i).Move(1, 0);
                        st.getObj(i).Update();
                    }
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < st.count; i++)
                {
                    if (st.getObj(i).Select())
                    {
                        st.getObj(i).Move(-1, 0);
                        st.getObj(i).Update();
                    }
                }
            }

            if (e.KeyCode == Keys.Add)
            {
                for (int i = 0; i < st.count; i++)
                {
                    if (st.getObj(i).Select())
                    {
                        st.getObj(i).changesize(1);
                        st.getObj(i).Update();
                    }
                }
            }

            if (e.KeyCode == Keys.Subtract)
            {
                for (int i = 0; i < st.count; i++)
                {
                    if (st.getObj(i).Select())
                    {
                        st.getObj(i).changesize(-1);
                        st.getObj(i).Update();
                    }
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            check = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < st.count; i++)
            {
                if (st.getObj(i).Select())
                {
                    st.getObj(i).RePaint(1);
                    st.getObj(i).Update();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < st.count; i++)
            {
                if (st.getObj(i).Select())
                {
                    st.getObj(i).RePaint(2);
                    st.getObj(i).Update();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < st.count; i++)
            {
                if (st.getObj(i).Select())
                {
                    st.getObj(i).RePaint(3);
                    st.getObj(i).Update();
                }
            }
        }
    }
    
}
