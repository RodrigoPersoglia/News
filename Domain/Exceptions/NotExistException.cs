namespace Domain.Exceptions
{
    public class NotExistException : Exception
    {
        public override string Message => $"No existe el recurso solicitado";
    }
}
