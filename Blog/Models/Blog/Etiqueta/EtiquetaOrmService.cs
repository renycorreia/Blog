using Blog.Models.Blog.Etiqueta;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Etiqueta
{
    public class EtiquetaOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public EtiquetaOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<EtiquetaEntity> ObterEtiquetas()
        {
            return _databaseContext.Etiquetas
                .ToList();
        }

        public EtiquetaEntity ObterEtiquetaPorId(int idEtiqueta)
        {
            var etiqueta = _databaseContext.Etiquetas.Find(idEtiqueta);

            return etiqueta;
        }

        public List<EtiquetaEntity> PesquisarEtiquetasPorNome(string nomeEtiqueta)
        {
            return _databaseContext.Etiquetas.Where(c => c.Nome.Contains(nomeEtiqueta)).ToList();
            
        }
    }
}
