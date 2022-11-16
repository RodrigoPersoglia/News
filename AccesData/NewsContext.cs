using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace AccesData
{
    public class NewsContext : DbContext
    {
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Reaccion> Reaccion { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=G100603NT283;Database=News;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=RODRIGONOTEBOOK\SQLEXPRESS;Database=News;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.UserName).HasMaxLength(45).IsRequired();
                entity.Property(c => c.Password).HasMaxLength(16).IsRequired();
                entity.Property(c => c.Email).HasMaxLength(45).IsRequired();
                entity.Property(c => c.Foto).IsRequired(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Description).HasMaxLength(45).IsRequired();
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categoria");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Description).HasMaxLength(45).IsRequired();
            });

            modelBuilder.Entity<Reaccion>(entity =>
            {
                entity.ToTable("Reaccion");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Like).IsRequired();
                entity.Property(c => c.ComentarioId).IsRequired();
                entity.Property(c => c.UserId).IsRequired();

                entity.HasOne(x => x.Comentario)
                    .WithMany(a => a.Reacciones)
                    .HasForeignKey(x => x.ComentarioId);

                entity.HasOne(x => x.User)
                    .WithMany(a => a.Reacciones)
                    .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.ToTable("Comentario");
                entity.HasKey(e => e.Id);
                entity.Property(c => c.FechaHora).IsRequired();
                entity.Property(c => c.Cuerpo).IsRequired();
                entity.Property(c => c.ComentarioId).IsRequired(false);
                entity.Property(c => c.UserId).IsRequired();
                entity.Property(c => c.NoticiaId).IsRequired();

                entity.HasOne(x => x.User)
                    .WithMany(a => a.Comentarios)
                    .HasForeignKey(x => x.UserId);

                entity.HasOne(x => x.Noticia)
                    .WithMany(a => a.Comentarios)
                    .HasForeignKey(x => x.NoticiaId);
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.ToTable("Noticia");
                entity.HasKey(e => e.Id);
                entity.Property(c => c.FechaHora).IsRequired();
                entity.Property(c => c.Titulo).HasMaxLength(50).IsRequired();
                entity.Property(c => c.Subtitulo).HasMaxLength(100).IsRequired();
                entity.Property(c => c.Volanta).HasMaxLength(100).IsRequired(false);
                entity.Property(c => c.Bajada).HasMaxLength(200).IsRequired();
                entity.Property(c => c.Cuerpo).IsRequired();
                entity.Property(c => c.Imagen).IsRequired();
                entity.Property(c => c.Epigrafe).HasMaxLength(100).IsRequired(false);
                entity.Property(c => c.CategoriaId).IsRequired();

                entity.HasOne(x => x.Categoria)
                    .WithMany(a => a.Noticias)
                    .HasForeignKey(x => x.CategoriaId);

            });


        }

    }
}