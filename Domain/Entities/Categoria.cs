namespace Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //propiedades de Navegacion
        public virtual ICollection<Noticia> Noticias { get; set; }
    }
}
