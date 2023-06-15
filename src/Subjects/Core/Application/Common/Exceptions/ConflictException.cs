namespace Goodtocode.Subjects.Application.Common.Exceptions;

public class ConflictException : Exception
{
    public ConflictException()
    {
    }

    public ConflictException(string message)
        : base(message)
    {
    }

    public ConflictException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ConflictException(string name, string duplicateReason)
        : base($"Entity \"{name}\" is a duplicated by {duplicateReason}.")
    {
    }
}