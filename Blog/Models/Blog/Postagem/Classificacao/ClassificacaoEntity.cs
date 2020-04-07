using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Classificacao
{
    [Table("classificacoes")]
    public class ClassificacaoEntity
    {
        [Key]
        [Column("ClassificacaoId")]
        public int Id { get; set; }
        
        [Required]
        public bool Classificacao { get; set; }

        [Column("PostagemId")]
        public PostagemEntity Postagem { get; set; }
    }
}
