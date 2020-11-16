using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var square = new Square();
            var circle = new Circle();
            var rectangle = new Rectangle();

            var ge = new GraphicEditor();
            Console.WriteLine(ge.DrawShape(rectangle));
        }
    }
}
