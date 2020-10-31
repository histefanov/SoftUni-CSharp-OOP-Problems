using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new RandomList();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Dumbledore");
            list.Add("Voldemort");
            list.Add("Iron man");

            var randomItem = list.RandomString();
            Console.WriteLine(randomItem);
            Console.WriteLine(list.Count);
        }
    }
}
