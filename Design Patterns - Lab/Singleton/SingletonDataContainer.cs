using Singleton.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer _instance;
        private Dictionary<string, int> _capitals;

        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object...");

            this._capitals = new Dictionary<string, int>();
            var elements = File.ReadAllLines("../../../capitals.txt");
            
            for (int i = 0; i < elements.Length; i += 2)
            {
                this._capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonDataContainer();
                }
                return _instance;
            }
        }

        public int GetPopulation(string name)
        {
            return this._capitals[name];
        }
    }
}
