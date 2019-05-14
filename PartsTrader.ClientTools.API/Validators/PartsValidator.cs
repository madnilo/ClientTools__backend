using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PartsTrader.ClientTools.API.Validators
{
    //public class DefaultValidator<T> : IValidatorBase<T>
    public class PartsValidator : IPartsValidator
    {

        //public bool IsValid(T obj)
        //{
        //    return Validate(obj).Count == 0;
        //}

        //private List<ValidationResult> Validate(T model)
        //{
        //    var errors = new List<ValidationResult>();

        //    var ctx = new ValidationContext(model);

        //    Validator.TryValidateObject(model, ctx, errors, true);

        //    return errors;
        //}

        public bool IsPartNumberValid(string partNumber)
        {
            var regex = new Regex(@"\d{4}-[a-z0-9A-Z]{4}[a-z0-9A-Z]*");

            return regex.Matches(partNumber).Count == 1;
        }

        public bool IsPartTitleValid(string partNumber)
        {
            return partNumber.Length > 0;
        }

    }
}
