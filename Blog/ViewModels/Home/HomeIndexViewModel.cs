using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class HomeIndexViewModel
    {
        public string TituloPagina { get; set; }
        '
        public ICollection<PostagemHomeIndex> Postagens;

        public ICollection<Categoria> Categorias { get; set; }

        public ICollection<Etiqueta> Etiquetas { get; set; }

        public ICollection<PostagemPopular> PostagensPopulares { get; set; }

        public HomeIndexViewModel()
        {
            Postagens = new List<PostagemHomeIndex>();
            Categorias = new List<Categoria>();
            Etiquetas = new List<Etiqueta>();
            PostagensPopulares = new List<PostagemPopular>();
        }

    }


    public class PostagemHomeIndex
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string NumeroComentarios { get; set; }

        public string PostagemId { get; set; }
    }

    public class Etiqueta
    {
        public string Nome { get; set; }
        public int EtiquetaId { get; set; }
    }

    public class Categoria
    {
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
    }

    public class PostagemPopular
    {
        public string Titulo { get; set; }
        public int PostagemId { get; set; }
    }

}
