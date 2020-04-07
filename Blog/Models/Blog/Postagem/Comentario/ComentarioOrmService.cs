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

