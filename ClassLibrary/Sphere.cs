using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Sphere : Shape3D
    {
        public override Vector3 Center { get; }
        public override float Area { get; } 
        public override float Volume { get; }

        public float Radius { get; }
        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
            Area =(float) ((float) 4 * Math.PI * radius * radius);
            Volume = (float)((float)1.3333333 * Math.PI * radius * radius * radius);
        }
        public override string ToString()
        {
            return $"Sphere @({Center.X}, {Center.Y}, {Center.Z}): r = {Radius}";
        }
    }
}
