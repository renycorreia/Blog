using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Comentario
{
    public class ComentarioOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public ComentarioOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ComentarioEntity> ObterComentarios()
        {
            var primeiraComentarioOuNulo = _databaseContext.Comentarios.FirstOrDefault();

            var algumaComentarioOuNulo = _databaseContext.Comentarios.SingleOrDefault(c => c.Id == 3);

            var encontrarComentario = _databaseContext.Comentarios.Find(3);

            var todascomentarios = _databaseContext.Comentarios.ToList();

            var comentariosESuascomentarios = _databaseContext.Comentarios
                .ToList();

            var comentariosSemcomentarios = _databaseContext.Comentarios
                .ToList();

            var comentariosComcomentarios = _databaseContext.Comentarios
                .ToList();

            return _databaseContext.Comentarios
                .ToList();
        }

        public ComentarioEntity ObterComentarioPorId(int idComentario)
        {
            var comentario = _databaseContext.Comentarios.Find(idComentario);

            return comentario;
        }
    }
}

