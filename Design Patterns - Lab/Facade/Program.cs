using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                    .WithType("VW")
                    .WithColor("Blue")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Leipzig")
                    .AtAddress("Golfstrasse 24")
                .Build();

            Console.WriteLine(car);
        }
    }
}
