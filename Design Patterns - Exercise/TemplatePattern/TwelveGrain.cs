using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Collecting and mixing ingredients for the twelve grain bread");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the twelve grain bread... (approx. 32 minutes)");
        }
    }
}
