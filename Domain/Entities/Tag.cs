namespace Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            this.Noticias = new HashSet<Noticia>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        //propiedades de Navegacion
        public virtual ICollection<Noticia> Noticias { get; set; }
    }
}
