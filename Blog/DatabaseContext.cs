﻿using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CategoriaEntity> categorias { get; set; }
        public DbSet<AutorEntity> autores { get; set; }
        public DbSet<EtiquetaEntity> etiquetas { get; set; }
        public DbSet<PostagemEntity> postagens { get; set; }
        public DbSet<RevisaoEntity> revisoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("Server=localhost; User=root; password=root; Database=pwaBlog");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mapear realacionamentos entre as entidades
            modelBuilder.Entity<PostagemEntity>().HasOne(CategoriaEntity);
        }*/
    }
}
