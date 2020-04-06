using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Classificacao
{
    public class ClassificacaoOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public ClassificacaoOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ClassificacaoEntity> ObterClassificacoes()
        {
            var primeiraClassificacaoOuNulo = _databaseContext.Classificacoes.FirstOrDefault();

            var algumaClassificacaoOuNulo = _databaseContext.Classificacoes.SingleOrDefault(c => c.Id == 3);

            var encontrarClassificacao = _databaseContext.Classificacoes.Find(3);

            var todasclassificacoes = _databaseContext.Classificacoes.ToList();

            var classificacoesESuasclassificacoes = _databaseContext.Classificacoes
                .ToList();

            var classificacoesSemclassificacoes = _databaseContext.Classificacoes
                .ToList();

            var classificacoesComclassificacoes = _databaseContext.Classificacoes
                .ToList();

            return _databaseContext.Classificacoes
                .ToList();
        }

        public ClassificacaoEntity ObterClassificacaoPorId(int idClassificacao)
        {
            var classificacao = _databaseContext.Classificacoes.Find(idClassificacao);

            return classificacao;
        }

    }
}
