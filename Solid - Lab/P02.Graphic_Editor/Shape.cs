using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Shape : IShape
    {
        public string Draw()
        {
            return $"I'm {this.GetType().Name}";
        }
    }
}
