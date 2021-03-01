using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Rectangle : Shape2D
    {
        public override Vector3 Center { get; }
        public override float Area { get { return Size.X * Size.Y; } }
        public override float Circumference { get { return 2 * (Size.X + Size.Y); } }
        public bool IsSquare { get { return Size.X == Size.Y; } }

        public Vector2 Size { get; }
        public Rectangle(Vector2 center, Vector2 size)
        {
            Size = size;
            Center = new Vector3(center, 0);
        }
        public Rectangle (Vector2 center, float width) : this (center, new Vector2(width, width))
        {

        }
        public override string ToString()
        {
            if(IsSquare)
            {
                return $"Square @({Center.X}, {Center.Y}): w = {Size.X}, h = {Size.Y}";
            }
            else
            {
                return $"Rectangle @({Center.X}, {Center.Y}): w = {Size.X}, h = {Size.Y}";
            }
        }
    }
}
