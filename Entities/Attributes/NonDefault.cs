using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Attributes
{
    public class NonDefault : ValidationAttribute
    {
        public NonDefault(): base()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = true;

            if (value is null)
            {
                isValid = false;
            }

            var type = value.GetType();
            if (type.IsValueType)
            {
                var defaultValue = Activator.CreateInstance(type);
                if (!value.Equals(defaultValue))
                    isValid = true;
                else
                    isValid = false;
            }

            return isValid ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
