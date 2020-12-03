using Custom_DI_Framework.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Framework.Injectors
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
