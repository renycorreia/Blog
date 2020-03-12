using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.Models.Blog.Postagem.Revisao.Classificacao;
using Blog.Models.Blog.Postagem.Revisao.Comentario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("Server=localhost; User=root; password=root; Database=pwaBlog");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mapear realacionamentos entre as entidades
            //N:N (Postagens / Etiquetas)
            modelBuilder.Entity<PostagemEtiquetaEntity>()
                .ToTable("PostagemEtiqueta"); //nome da tabela

            modelBuilder.Entity<PostagemEtiquetaEntity>()
                .HasOne(pe => pe.Postagem)
                .WithMany(p => p.PostagemEtiqueta);

            modelBuilder.Entity<PostagemEtiquetaEntity>()
                .HasOne(pe => pe.Etiqueta)
                .WithMany(e => e.PostagemEtiqueta);
        }
    }
}
