using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao.Comentario
{
    public class ComentarioEntity
    {
        public RevisaoEntity revisaoComent;
        public DateTime dataComent;
        public string nomeAutorComent;
        public string emailAutorComent;
        public string textoComent;
    }
}
