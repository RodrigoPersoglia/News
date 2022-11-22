namespace Domain.Entities
{
    public class Reaccion
    {
        public int Id { get; set; }
        public bool Like { get; set; }
        public int UserId { get; set; }
        public int ComentarioId { get; set; }

        //propiedades de Navegacion
        public virtual User User { get; set; }
        public virtual Comentario Comentario { get; set; }
    }
}
