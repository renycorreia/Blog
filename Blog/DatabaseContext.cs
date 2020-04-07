using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.Models.Blog.Postagem.Classificacao;
using Blog.Models.Blog.Postagem.Comentario;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CategoriaEntity> Categorias { get; set; }

        public DbSet<AutorEntity> Autores { get; set; }

        public DbSet<EtiquetaEntity> Etiquetas { get; set; }

        public DbSet<PostagemEntity> Postagens { get; set; }

        public DbSet<RevisaoEntity> Revisoes { get; set; }

        public DbSet<ComentarioEntity> Comentarios { get; set; }

        public DbSet<ClassificacaoEntity> Classificacoes { get; set; }

        public DbSet<PostagemEtiquetaEntity> PostagensEtiquetas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("Server=localhost; User=root; password=root; Database=pwaBlog");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mapear relacionamentos entre as entidades
            //N:N (Postagens / Etiquetas)
            
            modelBuilder.Entity<PostagemEtiquetaEntity>()
                .ToTable("PostagensEtiquetas"); //nome da tabela

            modelBuilder.Entity<PostagemEtiquetaEntity>()
                .HasOne(pe => pe.Postagem)
                .WithMany(p => p.PostagensEtiquetas);

            modelBuilder.Entity<PostagemEtiquetaEntity>()
                .HasOne(pe => pe.Etiqueta)
                .WithMany(e => e.PostagensEtiquetas);
        }
    }
}
