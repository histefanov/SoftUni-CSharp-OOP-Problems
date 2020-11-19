using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();
            var extractedInfo = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(extractedInfo);
        }
    }
}
