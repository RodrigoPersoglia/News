namespace Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //propiedades de Navegacion
        public List<NoticiaTag> NoticiasTags { get; set; }
    }
}
