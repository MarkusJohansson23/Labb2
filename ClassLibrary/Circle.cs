using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Circle : Shape2D
    {
        public override Vector3 Center { get; }
        public override float Area { get; }
        public override float Circumference { get; }

        public Vector2 CenterPoint;
        public float Radius;
        public Circle(Vector2 centerPoint, float radius)
        {
            CenterPoint = centerPoint;
            Radius = radius;
            Area =(float) Math.PI * radius * radius;
            Circumference = (float)((float) radius * 2 * Math.PI);
        }
        public override string ToString()
        {
            return $"Circle @({CenterPoint.X}, {CenterPoint.Y}): r = {Radius}";
        }
    }
}
