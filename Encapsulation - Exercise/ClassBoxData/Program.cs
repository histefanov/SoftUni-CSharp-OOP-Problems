using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                var box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():F2}\n" +
                                  $"Lateral Surface Area - {box.GetLateralSurfaceArea():F2}\n" +
                                  $"Volume - {box.GetVolume():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
