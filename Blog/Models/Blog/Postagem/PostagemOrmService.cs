using System;
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
                .Include(a => a.Autor)
                .Include(pe => pe.PostagensEtiquetas)
                .Include(c => c.Categoria)
                .Include(r => r.Revisoes)
                .Include(cm => cm.Comentarios)
                .Include(cl => cl.Classificacoes)
                .Where(p => p.ExibirAPartirDe <= DateTime.Now)
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