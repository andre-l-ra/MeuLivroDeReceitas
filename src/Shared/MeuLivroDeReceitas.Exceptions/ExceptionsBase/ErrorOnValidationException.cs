namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : MeuLivroDeReceitasException
{
    public ErrorOnValidationException(IList<string> errors)
    {
        ErrorMessages = errors;
    }

    public IList<string> ErrorMessages { get; set; }

    
}