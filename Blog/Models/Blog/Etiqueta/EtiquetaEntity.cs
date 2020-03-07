using Blog.Models.Blog.Postagem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Etiqueta
{
    public class EtiquetaEntity
    {
        [Key]
        public int codTag { get; set; }

        [MaxLength(10), Required]
        public string nomeTag { get; set; }

        [MaxLength(10), Required]
        public string corTag { get; set; }

        //public List<PostagemEntity> postagemTag { get; set; }

    }
}
