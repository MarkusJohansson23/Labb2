using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public abstract class Shape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }

        public static Shape[] GenerateShape()
        {
            Shape[] shapesArray = new Shape[20];

            for (int i = 0; i < shapesArray.Length; i++)
            {
                Random rand = new Random();
                int value = rand.Next(0, 6);

                switch (value)
                {
                    case 0:
                        Vector2 circleCenter = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        float radius = rand.Next(0, 100);
                        shapesArray[i] = new Circle(circleCenter, radius);
                        break;

                    case 1:
                        Vector2 rectangleCenter = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        Vector2 rectangleSize = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        shapesArray[i] = new Rectangle(rectangleCenter, rectangleSize);
                        break;

                    case 2:
                        Vector2 p1 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        Vector2 p2 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        Vector2 p3 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        shapesArray[i] = new Triangle(p1, p2, p3);
                        break;

                    case 3:
                        Vector2 squareCenter = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        Vector2 squareSize = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        shapesArray[i] = new Square(squareCenter, squareSize);
                        break;

                    case 4:
                        Vector3 cuboidCenter = new Vector3(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
                        Vector3 cuboidSize = new Vector3(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
                        shapesArray[i] = new Cuboid(cuboidCenter, cuboidSize);
                        break;

                    case 5:
                        Vector3 sphereCenter = new Vector3(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
                        float sphereRadius = rand.Next(0, 100);
                        shapesArray[i] = new Sphere(sphereCenter, sphereRadius);
                        break;
                }
            }
            return shapesArray;
        }
        public static Shape[] GenerateShape(Vector3 position)//ändra centerposition till in parametern (position) på alla former
        {
            Shape[] shapesArray = new Shape[20];

            for (int i = 0; i < shapesArray.Length; i++)
            {
                Random rand = new Random();
                int value = rand.Next(0, 6);

                switch (value)
                {
                    case 0:
                        float radius = rand.Next(0, 100);
                        shapesArray[i] = new Circle(new Vector2(position.X, position.Y), radius);
                        break;

                    case 1:
                        Vector2 rectangleSize = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        shapesArray[i] = new Rectangle(new Vector2(position.X, position.Y), rectangleSize);
                        break;

                    case 2:
                        shapesArray[i] = GenerateTriangle(new Vector2(position.X, position.Y));
                        break;

                    case 3:
                        Vector2 squareSize = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                        shapesArray[i] = new Square(new Vector2(position.X, position.Y), squareSize);
                        break;

                    case 4:
                        Vector3 cuboidSize = new Vector3(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
                        shapesArray[i] = new Cuboid(new Vector3(position.X, position.Y, position.Z), cuboidSize);
                        break;

                    case 5:
                        float sphereRadius = rand.Next(0, 100);
                        shapesArray[i] = new Sphere(new Vector3(position.X, position.Y, position.Z), sphereRadius);
                        break;
                }
            }
            return shapesArray;
        }
        public static Triangle GenerateTriangle(Vector2 center)
        {
            var rand = new Random();

            var sumOfCorners = center * 3f;

            var corner1 = new Vector2(x: rand.Next(0, 100), y: rand.Next(0, 100));
            var corner2 = new Vector2(x: rand.Next(0, 100), y: rand.Next(0, 100));

            while (corner1 == corner2)
            {
                corner2 = new Vector2(x: rand.Next(0, 100), y: rand.Next(0, 100));
            }

            Vector2 corner3 = (sumOfCorners - corner1 - corner2);

            return new Triangle(corner1, corner2, corner3);
        }

    }
}
