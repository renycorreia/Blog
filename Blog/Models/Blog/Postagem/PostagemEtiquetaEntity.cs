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
        [Column("PostagemEtiquetaId")]
        public int Id { get; set; }

        [ForeignKey("PostagemId")]
        [Column("PostagemId")]
        public PostagemEntity Postagem { get; set; }

        [ForeignKey("EtiquetaId")]
        [Column("EtiquetaId")]
        public EtiquetaEntity Etiqueta { get; set; }
    }
}
