using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Cuboid : Shape3D
    {
        public override Vector3 Center { get; }
        public override float Area { get; }
        public override float Volume { get; }
        public Vector3 Size { get; }
        public Cuboid(Vector3 center, Vector3 size)
        {
            Center = center;
            Size = size;
            Area = (2 * Size.Z * Size.X) + (2 * Size.Z * Size.Y) + (2 * Size.X * Size.Y);
            Volume = Size.X * Size.Y * Size.Z;
        }
        public Cuboid(Vector3 center, float width) : this(center, new Vector3(width, width, width))
        {
            
        }
        public bool IsCube
        {
            get
            {
                return (Size.X == Size.Y && Size.X == Size.Z && Size.Y == Size.Z);
            }
        }
        public override string ToString()
        {
            if(IsCube)
            {
                return $"Cube @({Center.X}, {Center.Y}, {Center.Z}): w = {Size.X}, h = {Size.Y}, l = {Size.Z})";
            }
            else
            {
                return $"Cuboid @({Center.X}, {Center.Y}, {Center.Z}): w = {Size.X}, h = {Size.Y}, l = {Size.Z})";
            }
        }
    }
}
