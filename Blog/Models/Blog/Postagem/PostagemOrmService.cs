using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem.Revisao;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEntity> ObterPostagens()
        {
            return _databaseContext.Postagens
                .Include(a => a.Autor)
                .Include(pe => pe.PostagensEtiquetas)
                .Include(c => c.Categoria)
                .Include(r => r.Revisoes)
                .Include(cm => cm.Comentarios)
                .Include(cl => cl.Classificacoes)
                .Where(p => p.ExibirAPartirDe <= DateTime.Now)
                .ToList();
        }

        public List<PostagemEntity> ObterPostagensPopulares()
        {
            return _databaseContext.Postagens
                .Include(p => p.Comentarios)
                .OrderByDescending(p => p.Comentarios.Count).Take(4)
                .ToList();
        }

        public PostagemEntity ObterPostagemPorId(int idPostagem)
        {
            var postagem = _databaseContext.Postagens.Find(idPostagem);

            return postagem;
        }

        public PostagemEntity CriarPostagem(string titulo, string descricao, AutorEntity autor, CategoriaEntity categoria, DateTime exibirAPartirDe)
        {

            var novaPostagem = new PostagemEntity {Titulo = titulo, Descricao = descricao, Autor = autor, Categoria = categoria, ExibirAPartirDe = exibirAPartirDe };

            _databaseContext.Postagens.Add(novaPostagem);
            _databaseContext.SaveChanges();

            return novaPostagem;
        }

        public PostagemEntity EditarPostagem(int id, string titulo, string descricao, AutorEntity autor, CategoriaEntity categoria, DateTime exibirAPartirDe)
        {
            var postagem = _databaseContext.Postagens.Find(id);

            if (postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            postagem.Titulo = titulo;
            postagem.Descricao = descricao;
            postagem.Autor = autor;
            postagem.Categoria = categoria;
            postagem.ExibirAPartirDe = exibirAPartirDe;
            _databaseContext.SaveChanges();

            return postagem;
        }

        public bool RemoverPostagem(int id)
        {
            var postagem = _databaseContext.Postagens.Find(id);

            if (postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            _databaseContext.Postagens.Remove(postagem);
            _databaseContext.SaveChanges();

            return true;
        }

    }
}