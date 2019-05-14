using System;
namespace PartsTrader.ClientTools.API.Validators
{
    //public interface IValidatorBase<T>
    public interface IPartsValidator
    {
        //bool IsValid(T obj);
        bool IsPartNumberValid(string partNumber);
        bool IsPartTitleValid(string partNumber);
    }
}
