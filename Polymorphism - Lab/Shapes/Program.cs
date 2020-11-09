using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Rectangle(5, 6);
            Console.WriteLine(circle.Draw());
        }
    }
}
