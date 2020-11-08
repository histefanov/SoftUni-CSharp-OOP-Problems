using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var smartphone = new Smartphone();
            var phone = new StationaryPhone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            foreach (var num in phoneNumbers)
            {
                if (num.Length == 7)
                {
                    phone.Call(num);
                }
                else
                {
                    smartphone.Call(num);
                }
            }

            foreach (var site in websites)
            {
                smartphone.Browse(site);
            }
        }
    }
}
