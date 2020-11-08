using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StationaryPhone : ICaller
    {
        public void Call(string phoneNumber)
        {
            var validation = new Regex(@"\d{7}");
            if (validation.IsMatch(phoneNumber))
            {
                Console.WriteLine($"Dialing... {phoneNumber}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
