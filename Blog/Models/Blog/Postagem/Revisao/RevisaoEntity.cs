using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao
{
    [Table("revisoes")]
    public class RevisaoEntity
    {
        [Key]
        [Column("RevisaoId")]
        public int Id { get; set; }

        [ForeignKey("PostagemId")]
        [Column("PostagemId")]
        public PostagemEntity Postagem { get; set; }

        [Required]
        public string Texto { get; set; }

        public int Versao { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
