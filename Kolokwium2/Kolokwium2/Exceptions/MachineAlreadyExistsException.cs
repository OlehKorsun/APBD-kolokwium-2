namespace Kolokwium2.Exceptions;

public class MachineAlreadyExistsException : Exception
{
    public MachineAlreadyExistsException()
    {
    }

    public MachineAlreadyExistsException(string? message) : base(message)
    {
    }

    public MachineAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}