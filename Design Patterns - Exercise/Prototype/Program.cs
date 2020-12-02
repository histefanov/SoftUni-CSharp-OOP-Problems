using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var sandwichMenu = new SandwichMenu();

            sandwichMenu["BigMac"] = new Sandwich("white", "beef", "cheddar", "lettuce");
            sandwichMenu["Whopper"] = new Sandwich("white", "fried chicken", "emental", "lettuce");
            sandwichMenu["SubwaySandwich"] = new Sandwich("herbs&cheese", "pepperoni", "creme cheese", "tomatoes");

            var order1 = sandwichMenu["BigMac"].Clone() as Sandwich;
            var order2 = sandwichMenu["Whopper"].Clone() as Sandwich;
            var order3 = sandwichMenu["SubwaySandwich"].Clone() as Sandwich;
        }
    }
}
