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
            var primeiraRevisaoOuNulo = _databaseContext.Revisoes.FirstOrDefault();

            var algumaRevisaoOuNulo = _databaseContext.Revisoes.SingleOrDefault(c => c.Id == 3);

            var encontrarRevisao = _databaseContext.Revisoes.Find(3);

            var todasrevisoes = _databaseContext.Revisoes.ToList();

            var revisoesEmOrdemAlfabetica = _databaseContext.Revisoes.OrderBy(c => c.Texto).ToList();
            var revisoesEmOrdemAlfabeticaInversa = _databaseContext.Revisoes.OrderByDescending(c => c.Texto).ToList();

            var revisoesESuasrevisoes = _databaseContext.Revisoes
                .ToList();

            var revisoesSemrevisoes = _databaseContext.Revisoes
                .ToList();

            var revisoesComrevisoes = _databaseContext.Revisoes
                .ToList();

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
