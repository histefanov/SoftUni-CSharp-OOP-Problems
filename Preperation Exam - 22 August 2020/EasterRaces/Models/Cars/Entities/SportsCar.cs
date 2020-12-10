using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int CUBIC_CM = 3000;
        private const int MIN_HP = 250;
        private const int MAX_HP = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CUBIC_CM, MIN_HP, MAX_HP)
        {
        }
    }
}
