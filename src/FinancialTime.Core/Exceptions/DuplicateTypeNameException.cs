namespace FinancialTime.Core.Exceptions;

public class DuplicateTypeNameException : Exception
{
    public DuplicateTypeNameException(string name) : base($"A Type with {name} name already exists")
    {
    }
}