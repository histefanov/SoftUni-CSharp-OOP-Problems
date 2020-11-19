using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        public static void Main(string[] args)
        {
            Tracker.PrintMethodsByAuthor();
        }
    }
}
