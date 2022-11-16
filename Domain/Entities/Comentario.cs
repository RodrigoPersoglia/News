namespace Domain.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Cuerpo { get; set; }
        public int NoticiaId { get; set; }
        public int UserId { get; set; }
        public int? ComentarioId { get; set; }

        //propiedades de Navegacion
        public virtual Noticia Noticia { get; set; }
        public virtual User User { get; set; }
        public virtual Comentario? ComentarioOriginal { get; set; }
        public virtual ICollection<Reaccion> Reacciones { get; set; }


    }
}
