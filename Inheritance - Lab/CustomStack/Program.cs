using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            stack.Push("Angel");
            stack.Push("Boris");
            stack.Push("Cvetan");

            var stackRange = new Stack<string>();
            stackRange.Push("Dimitar");
            stackRange.Push("Eleonora");
            stack.AddRange(stackRange);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
