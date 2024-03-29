﻿namespace Domain.Entities
{
    public class ComentarioDtoOut
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Cuerpo { get; set; }
        public int NoticiaId { get; set; }
        public int UserId { get; set; }
        public int? ComentarioId { get; set; }

        public UserDtoOut User { get; set; }
        public List<ReaccionDtoOut> Reacciones { get; set; }


    }
}
