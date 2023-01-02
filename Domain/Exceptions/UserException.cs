namespace Domain.Exceptions
{
    public class UserException : Exception
    {
        public override string Message => $"El usuario y/o clave son inválidos.";
    }
}
