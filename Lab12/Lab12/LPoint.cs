using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesLib;

namespace Lab12
{
    public class LPoint<T> where T: Shape
    {
        public int key;
        public Shape value;
        public LPoint<T> next;
        public LPoint(Shape shape)
        {
            value = shape;
            key = GetHashCode();
            next = null;
        }
        public override int GetHashCode()
        {
            int code = 0;
            foreach (char c in value.Name)
                code += (int)c;
            return code;
        }
    }
}
