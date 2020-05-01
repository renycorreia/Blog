using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao
{
    public class RevisaoOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public RevisaoOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<RevisaoEntity> ObterRevisoes()
        {
            return _databaseContext.Revisoes
                .ToList();
        }

        public RevisaoEntity ObterRevisaoPorId(int idRevisao)
        {
            var revisao = _databaseContext.Revisoes.Find(idRevisao);

            return revisao;
        }

        public List<RevisaoEntity> ObterRevisoesPorPostagem(int idPostagem)
        {
            var postagem = new PostagemEntity();
            postagem.Id = idPostagem;

            var listaRevisao = _databaseContext.Revisoes
                .Where(r => r.Postagem == postagem)
                .ToList();

            return listaRevisao;
        }

        public List<RevisaoEntity> PesquisarrevisoesPorTexto(string textoRevisao)
        {
            return _databaseContext.Revisoes.Where(c => c.Texto.Contains(textoRevisao)).ToList();

        }

        public RevisaoEntity CriarRevisao(string texto, int versao, PostagemEntity postagem, DateTime dataCriacao)
        {

            var novaRevisao = new RevisaoEntity { Postagem = postagem, Texto = texto, Versao = versao, DataCriacao = dataCriacao };

            _databaseContext.Revisoes.Add(novaRevisao);
            _databaseContext.SaveChanges();

            return novaRevisao;
        }

        public RevisaoEntity EditarRevisao(int id, string texto, int versao, PostagemEntity postagem, DateTime dataCriacao)
        {
            var Revisao = _databaseContext.Revisoes.Find(id);

            if (Revisao == null)
            {
                throw new Exception("Revisao não encontrada!");
            }

            Revisao.Postagem = postagem;
            Revisao.Texto = texto;
            Revisao.Versao = versao;
            Revisao.DataCriacao = dataCriacao;
            _databaseContext.SaveChanges();

            return Revisao;
        }

        public bool RemoverRevisao(int id)
        {
            var Revisao = _databaseContext.Revisoes.Find(id);

            if (Revisao == null)
            {
                throw new Exception("Revisao não encontrada!");
            }

            _databaseContext.Revisoes.Remove(Revisao);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool RemoverRevisoesPorPostagem(int idPostagem)
        {
            var postagem = new PostagemEntity();
            postagem.Id = idPostagem;

            var listaRevisao = _databaseContext.Revisoes
                .Where(r => r.Postagem == postagem)
                .ToList();

            foreach (var revisao in listaRevisao)
            {
                if (revisao == null)
                {
                    throw new Exception("Revisao não encontrada!");
                }

                _databaseContext.Revisoes.Remove(revisao);
            }

            _databaseContext.SaveChanges();

            return true;
        }

    }
}
