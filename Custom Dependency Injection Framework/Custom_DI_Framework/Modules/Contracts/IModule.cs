using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Framework.Modules.Contracts
{
    public interface IModule
    {
        public void Configure();

        public Type GetMapping(Type currentInterface, object attribute);

        public object GetInstance(Type type);

        public void SetInstance(Type type, object instance);
    }
}
