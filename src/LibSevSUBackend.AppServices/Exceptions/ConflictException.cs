namespace LibSevSUBackend.AppServices.Exceptions;

public class ConflictException : Exception
{
    public ConflictException() : base("Conflict") { }
}