﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    {
    }
}
