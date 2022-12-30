namespace Domain.Entities
{
    public class Map_Noticia_Tag
    {
        public int NoticiaId { get; set; }
        public Noticia Noticia { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
