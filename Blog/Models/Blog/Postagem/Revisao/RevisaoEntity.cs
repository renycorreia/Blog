using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao
{
    public class RevisaoEntity
    {
        public PostagemEntity postagemRevisao;
        public string textoRevisao;
        public int versaoRevisao;
        public DateTime dataRevisao;
    }
}
