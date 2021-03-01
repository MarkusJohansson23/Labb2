using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Triangle : Shape2D, IEnumerator, IEnumerable
    {
        public override Vector3 Center { get; }
        public override float Area { get; }
        public override float Circumference { get; }

        public Vector2 P1 { get; }
        public Vector2 P2 { get; }
        public Vector2 P3 { get; }

        public Vector2[] points = new Vector2[3];
        public object Current { get { return Current; } }

        private int position;
        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            Area = (P1.X * (P2.Y - P3.Y) + P2.X * (P3.Y - P1.Y) + P3.X * (P1.Y - P2.Y)) / 2f;
            Circumference = (Vector2.Distance(P1, P2) + Vector2.Distance(P1, P3) + Vector2.Distance(P2, P3));
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
            Vector2 middlePoint = (P1 + P2 + P3) / 3f;
            Center = new Vector3(middlePoint.X, middlePoint.Y, 0);
        }
        public override string ToString()
        {
            return $"Triangle @({Center.X}, {Center.Y}): p1({P1.X}, {P1.Y}), p2({P2.X}, {P2.Y}), p3({P3.X}, {P3.Y})";
        }

        public bool MoveNext()
        {
            position++;
            return position < points.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return points.GetEnumerator();
        }
    }
}
