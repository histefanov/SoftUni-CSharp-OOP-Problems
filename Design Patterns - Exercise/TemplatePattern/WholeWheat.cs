using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Collecting and mixing ingredients for the whole wheat bread");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the whole wheat bread... (approx. 25 minutes)");
        }
    }
}
