using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Categoria
{
    [Table("categorias")]
    public class CategoriaEntity
    {
        [Key]
        public int CategoriaId { get; set; }

        [MaxLength(100), Required]
        public string Nome { get; set; }

        [ForeignKey("PostagemId")]
        public ICollection<PostagemEntity> Postagens { get; set; }

        [ForeignKey("EtiquetaId")]
        public ICollection<EtiquetaEntity> Etiquetas { get; set; }

        CategoriaEntity()
        {
            Postagens = new List<PostagemEntity>();
            Etiquetas = new List<EtiquetaEntity>();
        }

    }
}
