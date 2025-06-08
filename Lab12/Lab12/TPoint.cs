using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ShapesLib;

namespace Lab12
{
    public class TPoint<T> where T: Circle
    {
        public Circle data;
        public TPoint<T> left,
                         right;
        public TPoint()
        {
            data = new Circle();
            left = null;
            right = null;
        }
        public TPoint(Circle value)
        {
            data = value;
            left = null;
            right = null;
        }
    }
}
