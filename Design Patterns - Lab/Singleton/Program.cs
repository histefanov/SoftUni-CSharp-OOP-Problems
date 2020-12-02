using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Paris"));
        }
    }
}
