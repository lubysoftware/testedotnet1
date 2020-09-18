using System;
using System.ComponentModel.DataAnnotations;

namespace LubyClocker.CrossCuting.Shared.Validators
{
    public class RequiredEnumAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var type = value.GetType();
            return type.IsEnum && Enum.IsDefined(type, value);
        }
    }
}