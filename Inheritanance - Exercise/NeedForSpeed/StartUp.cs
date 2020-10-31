using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new SportCar(100, 100);
            car.Drive(20);
            Console.WriteLine(car.Fuel);
        }
    }
}
