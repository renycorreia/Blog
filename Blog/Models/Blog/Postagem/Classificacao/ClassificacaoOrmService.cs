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
