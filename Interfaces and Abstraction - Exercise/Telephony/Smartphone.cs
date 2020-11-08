using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Smartphone : ICaller, IBrowser
    {
        public void Call(string phoneNumber)
        {
            var validation = new Regex(@"\d{10}");
            if (validation.IsMatch(phoneNumber))
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public void Browse(string website)
        {
            var validation = new Regex(@"^\D+$");
            if (validation.IsMatch(website))
            {
                Console.WriteLine($"Browsing: {website}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}
