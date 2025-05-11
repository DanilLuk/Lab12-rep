using ShapesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Point : ICloneable
    {
        public Shape data;
        public Point next,
                     prev;
        public Point()
        {
            data = null;
            next = null;
            prev = null;
        }
        public Point(Shape obj)
        {
            data = obj;
            next = null;
            prev = null;
        }

        public object Clone()
        {
            Shape newData = (Shape)data.Clone();
            Point clone = new Point(newData);
            return clone;
        }
    }
}
