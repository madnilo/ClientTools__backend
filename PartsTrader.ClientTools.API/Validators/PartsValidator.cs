using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PartsTrader.ClientTools.API.Validators
{
    public class PartsValidator : IPartsValidator
    {

        public bool IsPartNumberValid(string partNumber)
        {
            var regex = new Regex(@"\d{4}-[a-z0-9A-Z]{4}[a-z0-9A-Z]*");

            return regex.Matches(partNumber).Count == 1;
        }

    }
}
