namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }

        //propiedades de Navegacion
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Reaccion> Reacciones { get; set; }
    }
}
