using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.Contracts
{
    interface ISingletonContainer
    {
        int GetPopulation(string name);
    }
}
