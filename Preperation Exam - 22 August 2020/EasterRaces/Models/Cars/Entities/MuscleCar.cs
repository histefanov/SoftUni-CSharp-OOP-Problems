using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int CUBIC_CM = 5000;
        private const int MIN_HP = 400;
        private const int MAX_HP = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CM, MIN_HP, MAX_HP)
        {
        }
    }
}
