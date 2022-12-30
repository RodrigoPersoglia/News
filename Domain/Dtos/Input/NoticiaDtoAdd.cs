namespace Domain.Entities
{
    public class NoticiaDtoAdd
    {
        public DateTime FechaHora { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string? Volanta { get; set; }
        public string Bajada { get; set; }
        public string Cuerpo { get; set; }
        public string Imagen { get; set; }
        public string? Epigrafe { get; set; }
        public int CategoriaId { get; set; }
        public ICollection<int> TagsId { get; set; }

    }
}
