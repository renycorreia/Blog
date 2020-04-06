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
            var primeiraAutorOuNulo = _databaseContext.Autores.FirstOrDefault();

            var algumaAutorOuNulo = _databaseContext.Autores.SingleOrDefault(c => c.Id == 3);

            var encontrarAutor = _databaseContext.Autores.Find(3);

            var todasautores = _databaseContext.Autores.ToList();

            var autoresComALetraG = _databaseContext.Autores.Where(c => c.Nome.StartsWith("G")).ToList();
            var autoresComALetraMouL = _databaseContext.Autores
                .Where(c => c.Nome.StartsWith("M") || c.Nome.StartsWith("L"))
                .ToList();

            var autoresEmOrdemAlfabetica = _databaseContext.Autores.OrderBy(c => c.Nome).ToList();
            var autoresEmOrdemAlfabeticaInversa = _databaseContext.Autores.OrderByDescending(c => c.Nome).ToList();

            var autoresESuasautores = _databaseContext.Autores
                .ToList();

            var autoresSemautores = _databaseContext.Autores
                .ToList();

            var autoresComautores = _databaseContext.Autores
                .ToList();

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
