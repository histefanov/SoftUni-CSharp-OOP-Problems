using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var elfka = new MuseElf("peshka", 80);
            Console.WriteLine(elfka);
        }
    }
}