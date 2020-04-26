using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Blog.Categoria
{
    public class CategoriaOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public CategoriaOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<CategoriaEntity> ObterCategorias()
        {
            return _databaseContext.Categorias
                .Include(c => c.Etiquetas)
                .ToList();
        }

        public CategoriaEntity ObterCategoriaPorId(int idCategoria)
        {
            var categoria = _databaseContext.Categorias.Find(idCategoria);

            return categoria;
        }

        public List<CategoriaEntity> PesquisarCategoriasPorNome(string nomeCategoria)
        {
            return _databaseContext.Categorias.Where(c => c.Nome.Contains(nomeCategoria)).ToList();

        }

        public CategoriaEntity CriarCategoria(string nome)
        {
            var novaCategoria = new CategoriaEntity { Nome = nome };
            _databaseContext.Categorias.Add(novaCategoria);
            _databaseContext.SaveChanges();

            return novaCategoria;
        }

        public CategoriaEntity EditarCategoria(int id, string nome)
        {
            var categoria = _databaseContext.Categorias.Find(id);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada!");
            }

            categoria.Nome = nome;
            _databaseContext.SaveChanges();

            return categoria;
        }

        public bool RemoverCategoria(int id)
        {
            var categoria = _databaseContext.Categorias.Find(id);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada!");
            }

            _databaseContext.Categorias.Remove(categoria);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}