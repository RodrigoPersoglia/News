namespace Domain.Entities
{
    public class Noticia
    {
        public Noticia()
        {
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string? Volanta { get; set; }
        public string Bajada { get; set; }
        public string Cuerpo { get; set; }
        public string Imagen { get; set; }
        public string? Epigrafe { get; set; }
        public int CategoriaId { get; set; }

        //propiedades de Navegacion
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public List<Map_Noticia_Tag> Map_Noticia_Tag { get; set; }

    }
}
