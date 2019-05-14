using System;
namespace PartsTrader.ClientTools.API.Validators
{
    public interface IPartsValidator
    {
        bool IsPartNumberValid(string partNumber);

    }
}
