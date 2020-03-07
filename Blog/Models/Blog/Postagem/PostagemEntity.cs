using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        [Key]
        public int CodPost { get; set; }
        
        [MaxLength(120), Required]
        public string TituloPost { get; set; }

        [Required]
        public AutorEntity AutorPost { get; set; }

        [Required]
        public CategoriaEntity CategoriaPost { get; set; }

        
        //public List<EtiquetaEntity> EtiquetasPost { get; set; }

        public List<RevisaoEntity> revisoesPost { get; set; }
    }
}
