using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEtiquetaOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemEtiquetaOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEtiquetaEntity> ObterPostagemEtiqueta()
        {
            return _databaseContext.PostagensEtiquetas
                //.Include(p => p.Autor)
                //.Include(p => p.PostagensEtiquetas)
                //.Include(p => p.Revisoes)
                //.Include(p => p.Comentarios)
                //.Include(p => p.Classificacoes)
                .ToList();
        }
    }
}