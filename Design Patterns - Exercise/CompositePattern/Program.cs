using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("iPhone", 1500);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var teddyBear = new SingleGift("Teddy bear", 25);
            var toyTruck = new SingleGift("Toy truck", 15);
            var doll = new SingleGift("Doll", 30);
            var car = new SingleGift("Remotely controlled car", 50);

            var santaBag = new CompositeGift("Santa's bag", 0);
            santaBag.Add(teddyBear);
            santaBag.Add(toyTruck);
            santaBag.Add(doll);
            santaBag.Add(car);

            Console.WriteLine($"Total price of Santa's bag is ${santaBag.CalculateTotalPrice()}");
        }
    }
}
