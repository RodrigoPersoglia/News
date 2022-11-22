namespace Domain.Entities
{
    public class ReaccionDtoOut
    {
        public int Id { get; set; }
        public bool Like { get; set; }
        public int ComentarioId { get; set; }
        public UserDtoOut User { get; set; }
    }
}
