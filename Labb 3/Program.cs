using System;
//using System.Linq;
using System.Numerics;
using ClassLibrary;

namespace Labb_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program GENERATE A SHAPE!");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Do you want to generate shapes with a random centerpoint...");
            Console.WriteLine("Or with a previously determined center point? ");
            Console.WriteLine("\nType 1 for a random center point.");
            Console.WriteLine("Type 2 for a previously determined center point.");
            Console.WriteLine("Type 0 to close the program.");
            Console.Write("Choice: ");

            bool validInput = true;
            int choice;

            double sumOfArea = 0;

            do
            {
                do
                {
                    string choiceString = Console.ReadLine();

                    if (int.TryParse(choiceString, out choice))
                    {
                        choice = int.Parse(choiceString);
                        validInput = true;
                    }
                    else
                    {
                        PrintWrongMessage();
                        validInput = false;
                    }
                }
                while (!validInput);

                if (choice == 1)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Shapes with a random center point: \n");

                    var shapes = Shape.GenerateShape();
                    var totalCircumference = CircumferenceOfTriangles(shapes);

                    for (int i = 0; i < shapes.Length; i++)
                    {
                        Console.WriteLine($"Shape {i + 1} = {shapes[i]}");
                        if (shapes[i] is Triangle)
                        {
                            var triangleObj = shapes[i] as Triangle;
                            foreach (var points in triangleObj)
                            {
                                Console.WriteLine(points);
                            }
                        }
                        sumOfArea = shapes[i].Area;
                    }
                    PrintResultOf(sumOfArea, totalCircumference);
                    Biggest3DShape(shapes);
                    break;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Shapes generated with the center point: ");
                    Console.WriteLine("X: 6");
                    Console.WriteLine("Y: 4");
                    Console.WriteLine("Z: 8");

                    var shapes2 = Shape.GenerateShape(new Vector3(6, 4, 8));
                    var totalCircumference = CircumferenceOfTriangles(shapes2);

                    for (int i = 0; i < shapes2.Length; i++)
                    {
                        Console.WriteLine($"Shape {i + 1} = {shapes2[i]}");
                        if(shapes2[i] is Triangle)
                        {
                            var triangleObj = shapes2[i] as Triangle;
                            foreach(var points in triangleObj)
                            {
                                Console.WriteLine(points);
                            }
                        }
                        sumOfArea = shapes2[i].Area;
                    }
                    PrintResultOf(sumOfArea, totalCircumference);
                    Biggest3DShape(shapes2);
                    break;
                }
                else if(choice == 0)
                {
                    break;
                }
                else
                {
                    PrintWrongMessage();
                }
            } while (choice != 0) ;
            
            Console.WriteLine("\nClosing the program. Have a nice day! :)");

            Console.ReadKey();
        }
        public static double CircumferenceOfTriangles(Shape[] shapes) //TODO kolla ifall omkrets måste delas på 2
        {
            double sumOfTriangle = 0;
            for (int i = 0; i < shapes.Length; i++)
            {
                var triangle = shapes[i];

                if (triangle is Triangle)
                {
                    sumOfTriangle += (triangle as Triangle).Circumference;
                }
            }
            return sumOfTriangle;

        }
        public static void Biggest3DShape(Shape[] shapes)
        {
            var biggest3dShapeVolume = 0f;
            var biggest3dShapeName = "";
            foreach (var shape in shapes)
            {
                if (shape is Shape3D)
                {
                    var shape3d = shape as Shape3D;
                    if (shape3d.Volume > biggest3dShapeVolume)
                    {
                        biggest3dShapeVolume = shape3d.Volume;
                        biggest3dShapeName = shape3d.ToString();
                    }
                }
            }
            Console.Write($"The shape with the biggest volume is: ");
            Console.Write(biggest3dShapeName + ". ");
            Console.WriteLine($"Volume: {biggest3dShapeVolume}");
        }
        public static void PrintWrongMessage()
        {
            Console.WriteLine("Invalid input. Make sure to only typ 1, 2 or 0.");
            Console.WriteLine("\nType 1 for a random center point.");
            Console.WriteLine("Type 2 for a previously determined center point.");
            Console.WriteLine("Type 0 to close the program.");
        }
        public static void PrintResultOf(double sumOfArea, double totalCircumference)
        {
            Console.WriteLine($"\nThe area of the shapes is {sumOfArea / 20}");
            Console.WriteLine($"The circumference of all triangles is {totalCircumference}");
            
        }
    }
}
