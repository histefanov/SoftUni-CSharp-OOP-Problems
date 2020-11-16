using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var file = new File("file", 10, 5);
            var song = new Music("metallica", "nothing else matters", 15, 9);

            var spi = new StreamProgressInfo(song);
            Console.WriteLine(spi.CalculateCurrentPercent());
        }
    }
}
