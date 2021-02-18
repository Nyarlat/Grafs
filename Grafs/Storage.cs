using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafs
{
    public class MyStorage
    {
        public Shape[] objects;
        public int count;
        public int size;
        public MyStorage()
        {
            size = 100;
            objects = new Shape[size];
            count = 0;
        }
        virtual public void add(Shape NewObj)
        {
            objects[count] = NewObj;
            count++;
        }
        virtual public void del(int index)
        {
            for (int i = index; i < count; i++)
            {
                objects[i] = objects[i + 1];
            }
            count--;
        }
        virtual public Shape createShape(string code)
        {
            return null;
        }
        virtual public Shape getObj(int index)
        {
            return objects[index];
        }

        public void remove_all()
        {
            objects = null;
            objects = new Shape[size];
            count = 0;
        }
        private void copy(MyStorage other_st)
        {
            for (int i = 0; i < other_st.count; ++i)
                this.add(other_st.getObj(i));
        }
        public void load(StreamReader reader)
        {
            int countload = Convert.ToInt32(reader.ReadLine());
            Fabrica factory_st = new Fabrica();
            for (int i = 0; i < countload; ++i)
            {
                string s = reader.ReadLine();
                factory_st.add(factory_st.createShape(s));
                factory_st.getObj(i).Load(reader);
            }

            copy(factory_st);

        }
        public void save(StreamWriter writer)
        {
            writer.WriteLine(count);
            for (int i = 0; i < count; ++i)
                getObj(i).Save(writer);
        }
    }
}
