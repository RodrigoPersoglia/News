namespace Domain.Entities
{
    public class ComentarioDtoOut
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Cuerpo { get; set; }
        public int NoticiaId { get; set; }
        public int UserId { get; set; }
        public int? ComentarioId { get; set; }

        public virtual UserDtoOut User { get; set; }
        //public virtual Comentario? ComentarioOriginal { get; set; }
        public virtual ICollection<ReaccionDtoOut> Reacciones { get; set; }


    }
}
