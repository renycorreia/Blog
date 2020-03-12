using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao.Classificacao
{
    [Table("classificacoes")]
    public class ClassificacaoEntity
    {
        [Key]
        public int ClassificacaoId { get; set; }

        [ForeignKey("PostagemId")]
        public PostagemEntity Postagem { get; set; }
        public bool Classificacao { get; set; }
    }
}
