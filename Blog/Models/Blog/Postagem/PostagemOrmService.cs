using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEntity> ObterPostagens()
        {
            return _databaseContext.Postagens
                .Include(p => p.Autor)
                .Include(p => p.PostagensEtiquetas)
                .Include(p => p.Categoria)
                //.Include(p => p.Revisoes)
                .Include(p => p.Comentarios)
                .Include(p => p.Classificacoes)
                .ToList();
        }

        public List<PostagemEntity> ObterPostagensPopulares()
        {
            return _databaseContext.Postagens
                .Include(p => p.Comentarios)
                .OrderByDescending(p => p.Comentarios.Count).Take(4)
                .ToList();
        }
        
    }
}