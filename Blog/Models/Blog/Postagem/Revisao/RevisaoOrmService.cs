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

        public List<RevisaoEntity> PesquisarrevisoesPorTexto(string textoRevisao)
        {
            return _databaseContext.Revisoes.Where(c => c.Texto.Contains(textoRevisao)).ToList();

        }
    }
}
