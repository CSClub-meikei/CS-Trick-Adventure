using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Struct
{
    public struct Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public Circle(double x,double y,double radius):this()
        {
            X = x;
            Y = y;
            Radius = radius;

        }
    }
}
