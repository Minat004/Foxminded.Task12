namespace FinancialTime.Core.Exceptions;

public class RemoveNotEmptyTypeException : Exception
{
    public RemoveNotEmptyTypeException() : base("Cant remove not empty Type")
    {
    }
}