using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafs
{
    class MyStorage<figures>
    {
        public figures[] objects;
        public int count;
        public int size;
        public MyStorage(int _size)
        {
            size = _size;
            objects = new figures[_size];
            count = 0;
        }
        public void add(figures NewObj)
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
        public figures getObj(int index)
        {
            return objects[index];
        }
    }
}
