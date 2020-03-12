using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.Models.Blog.Postagem.Revisao.Classificacao;
using Blog.Models.Blog.Postagem.Revisao.Comentario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    [Table("postagens")]
    public class PostagemEntity
    {
        [Key]
        public int PostagemId { get; set; }
        
        [MaxLength(120), Required]
        public string Titulo { get; set; }

        [Required]
        public AutorEntity Autor { get; set; }

        [Required]
        public CategoriaEntity Categoria { get; set; }

        [ForeignKey("PostagemEtiquetaId")]
        public List<PostagemEtiquetaEntity> PostagemEtiqueta { get; set; }

        [ForeignKey("RevisaoId")]
        public ICollection<RevisaoEntity> Revisao { get; set; }

        [ForeignKey("ComentarioId")]
        public ICollection<ComentarioEntity> Comentario { get; set; }

        [ForeignKey("ClassificacaoId")]
        public ICollection<ClassificacaoEntity> Classificacao { get; set; }

        public PostagemEntity()
        {
            PostagemEtiqueta = new List<PostagemEtiquetaEntity>();
            Revisao = new List<RevisaoEntity>();
            Comentario = new List<ComentarioEntity>();
            Classificacao = new List<ClassificacaoEntity>();
        }
    }
}
