using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(Stack<string> stack)
        {
            List<string> range = new List<string>();
            while (stack.Count > 0)
            {
                range.Add(stack.Pop());
            }

            for (int i = range.Count - 1; i >= 0; i--)
            {
                this.Push(range[i]);
            }
        }
    }
}
