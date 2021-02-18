using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafs
{
    public partial class Form1 : Form
    {
        MyStorage st = new MyStorage();
        Bitmap bm;
        Graphics Paper;
        RectangleF Rect;
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pb1.Width - 1, pb1.Height - 1);
            Paper = Graphics.FromImage(bm);
            pb1.Image = bm;
            Rect = new RectangleF(pb1.Location.X-160, pb1.Location.Y , pb1.Width - 10, pb1.Height - 10);
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
                st.add(new CCircle(e.X, e.Y, Rect));
                else if (rdSquare.Checked)
                st.add(new Square(e.X, e.Y, Rect));
                else
                st.add(new Triangle(e.X, e.Y, Rect));
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

            int dx=0;
            int dy = 0;
            int size = 0;
            int color = 1;

            switch (e.KeyCode)
            {
                case Keys.W:
                    dy = -1;
                    break;
                case Keys.S:
                    dy = 1;
                    break;
                case Keys.D:
                    dx = 1;
                    break;
                case Keys.A:
                    dx = -1;
                    break;
                case Keys.Add:
                    size = 1;
                    break;
                case Keys.Subtract:
                    size = -1;
                    break;
                case Keys.D1:
                    color = 1;
                    break;
                case Keys.D2:
                    color = 2;
                    break;
                case Keys.D3:
                    color = 3;
                    break;
                default: break;
            }
            for (int i = 0; i < st.count; i++)
            {
                if (st.getObj(i).Select())
                {
                    st.getObj(i).RePaint(color);
                    st.getObj(i).Move(dx, dy);
                    st.getObj(i).changesize(size);
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            check = false;
        }


        private void bGroup_Click(object sender, EventArgs e)
        {
            CGroup shapes = new CGroup(15,Rect);
            for (int i = 0; i < st.count; i++)
            {
                if (st.getObj(i).Select())
                {
                    shapes.addShape(st.getObj(i));
                    st.del(i);
                    --i;
                }
            }
            st.add(shapes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            st.remove_all();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.DefaultExt = ".txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    st.save(sw);
                }
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {

            OpenFileDialog loadfile = new OpenFileDialog();
            loadfile.DefaultExt = ".txt";
            if (loadfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sw = new StreamReader(loadfile.FileName);
                st.remove_all();
                st.load(sw);
                sw.Close();
            }
        }
    }
    
}
