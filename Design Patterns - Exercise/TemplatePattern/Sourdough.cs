using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Collecting and mixing ingredients for the sourdough bread");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the sourdough bread... (approx. 35 minutes)");
        }
    }
}
