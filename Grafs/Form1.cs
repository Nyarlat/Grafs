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
        MyStorage st = new MyStorage();
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

        private void pb1_MouseClick(object sender, MouseEventArgs e)
        {
            st.add(new CCircle(e));
            pb1.Invalidate();
        }

        

    }

    class CCircle
    {
        public int x;
        public int y;
        public int radius = 30;

        public CCircle(MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Brushes.Black, 3), (x - radius), (y - radius), 2 * radius, 2 * radius);
        }
    }
    class MyStorage
    {
        public CCircle[] objects;
        public int count;
        public MyStorage()
        {
            objects = new CCircle[100];
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
