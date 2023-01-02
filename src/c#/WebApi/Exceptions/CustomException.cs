namespace WebApi.Exceptions;
using System.Runtime.Serialization;

[Serializable()]
internal class CustomException : Exception
{
    public CustomException() { }
    public CustomException(string message) : base(message) { }
    public CustomException(string message, System.Exception inner) : base(message, inner) { }
    protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}