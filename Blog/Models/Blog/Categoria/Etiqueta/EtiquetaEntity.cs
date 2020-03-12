using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Etiqueta
{
    [Table("etiquetas")]
    public class EtiquetaEntity
    {
        [Key]
        public int EtiquetaId { get; set; }

        [MaxLength(10), Required]
        public string Nome { get; set; }

        [MaxLength(10), Required]
        public string Cor { get; set; }

        [ForeignKey("PostagemEtiquetaId")]
        public List<PostagemEtiquetaEntity> PostagemEtiqueta { get; set; }

        [ForeignKey("CategoriaId")]
        public CategoriaEntity Categoria { get; set; }

        public EtiquetaEntity()
        {
            PostagemEtiqueta = new List<PostagemEtiquetaEntity>();
        }

    }
}
