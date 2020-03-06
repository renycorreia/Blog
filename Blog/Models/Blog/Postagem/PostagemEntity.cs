using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        public string tituloPost;
        public AutorEntity autorPost;
        public CategoriaEntity categoriaPost;
        public List<EtiquetaEntity> etiquetasPost;
        public List<RevisaoEntity> revisaoesPost;
    }
}
