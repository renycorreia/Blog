using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Autor
{
    public class AutorOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public AutorOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<AutorEntity> ObterAutores()
        {
            return _databaseContext.Autores
                .ToList();
        }

        public AutorEntity ObterAutorPorId(int idAutor)
        {
            var autor = _databaseContext.Autores.Find(idAutor);

            return autor;
        }

        public List<AutorEntity> PesquisarautoresPorNome(string nomeAutor)
        {
            return _databaseContext.Autores.Where(c => c.Nome.Contains(nomeAutor)).ToList();

        }
    }
}
