using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.Models.Blog.Postagem.Classificacao;
using Blog.Models.Blog.Postagem.Comentario;
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
        [Column("PostagemId")]
        public int Id { get; set; }

        [MaxLength(120)]
        [Required]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descricao { get; set; }

        public DateTime ExibirAPartirDe { get; set; }

        [Required]
        public AutorEntity Autor { get; set; }

        [Required]
        [Column("CategoriaId")]
        public CategoriaEntity Categoria { get; set; }

        [Column("PostagemEtiquetaId")]
        public List<PostagemEtiquetaEntity> PostagensEtiquetas { get; set; }

        [Column("RevisaoId")]
        public ICollection<RevisaoEntity> Revisoes { get; set; }

        public ICollection<ComentarioEntity> Comentarios { get; set; }

        public ICollection<ClassificacaoEntity> Classificacoes { get; set; }

        public PostagemEntity()
        {
            PostagensEtiquetas = new List<PostagemEtiquetaEntity>();
            Revisoes = new List<RevisaoEntity>();
            Comentarios = new List<ComentarioEntity>();
            Classificacoes = new List<ClassificacaoEntity>();
        }
    }
}
