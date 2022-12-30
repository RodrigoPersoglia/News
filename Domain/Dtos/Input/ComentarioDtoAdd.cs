namespace Domain.Entities
{
    public class ComentarioDtoAdd
    {
        public DateTime FechaHora { get; set; }
        public string Cuerpo { get; set; }
        public int NoticiaId { get; set; }
        public int UserId { get; set; }
        public int? ComentarioId { get; set; }

    }
}
