using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LubyClocker.CrossCuting.Shared.Validators
{
    public class RequiredDateTimeAttribute : ValidationAttribute
    {
        public RequiredDateTimeAttribute()
        {
            ErrorMessage = "The {0} field is required";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value is DateTime)
            {
                return (DateTime) value != DateTime.MinValue;
            }

            throw new ArgumentException("The {0} field is required");
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }

}