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

        internal object CriarComentario(PostagemEntity postagem, string texto, string autor, DateTime datacriacao, ComentarioEntity comentarioPai)
        {
            var novoComentario = new ComentarioEntity {Postagem = postagem, Texto = texto, Autor = autor, DataCriacao = datacriacao, ComentarioPai = comentarioPai};

            _databaseContext.Comentarios.Add(novoComentario);
            _databaseContext.SaveChanges();

            return novoComentario;


        }

        public bool RemoverComentario(int id)
        {
            var comentario = _databaseContext.Comentarios.Find(id);

            if (comentario == null)
            {
                throw new Exception("Comentario não encontrado!");
            }

            _databaseContext.Comentarios.Remove(comentario);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}

