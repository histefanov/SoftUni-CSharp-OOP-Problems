using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationAttributes.Attributes;
using ValidationAttributes.Contracts;

namespace ValidationAttributes.Models
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            var objProps = obj
                .GetType()
                .GetProperties();

            foreach (var prop in objProps)
            {
                var validationAtts = prop
                    .GetCustomAttributes(true)
                    .Where(a => a is IValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in validationAtts)
                {
                    if (!attribute.IsValid(prop.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
