namespace Domain.Entities
{
    public class Noticia
    {
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
        public List<NoticiaTag> NoticiasTags { get; set; }

    }
}
