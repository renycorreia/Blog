﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public string TituloPagina { get; set; }
        
        public ICollection<PostagemHomeIndex> Postagens { get; set; }

        public ICollection<CategoriaHomeIndex> Categorias { get; set; }

        public ICollection<EtiquetaHomeIndex> Etiquetas { get; set; }

        public ICollection<PostagemPopularHomeIndex> PostagensPopulares { get; set; }

        public HomeIndexViewModel()
        {
            Postagens = new List<PostagemHomeIndex>();
            Categorias = new List<CategoriaHomeIndex>();
            Etiquetas = new List<EtiquetaHomeIndex>();
            PostagensPopulares = new List<PostagemPopularHomeIndex>();
        }

    }


    public class PostagemHomeIndex
    {
        public string Titulo { get; set; }
        
        public string Data { get; set; }
        
        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string NumeroComentarios { get; set; }

        public string PostagemId { get; set; }
    }
    
    public class CategoriaHomeIndex
    {
        public string Nome { get; set; }
        public string CategoriaId { get; set; }
    }
    
    public class EtiquetaHomeIndex
    {
        public string Nome { get; set; }
        public string EtiquetaId { get; set; }
    }
    
    public class PostagemPopularHomeIndex
    {
        public string Titulo { get; set; }
        public string PostagemId { get; set; }
        public string Categoria { get; set; }
    }

}
