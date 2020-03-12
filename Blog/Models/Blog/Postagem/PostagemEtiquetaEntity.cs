using Blog.Models.Blog.Etiqueta;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    [Table("PostagemEtiqueta")]
    public class PostagemEtiquetaEntity
    {
        [Key]
        public int PostagemEtiquetaId { get; set; }

        [ForeignKey("PostagemId")]
        public PostagemEntity Postagem { get; set; }

        [ForeignKey("EtiquetaId")]
        public EtiquetaEntity Etiqueta { get; set; }
    }
}
