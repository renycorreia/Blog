using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao.Comentario
{
    [Table("comentarios")]
    public class ComentarioEntity
    {
        [Key]
        public int ComentarioId { get; set; }

        [ForeignKey("PostagemId")]
        public PostagemEntity Postagem { get; set; }

        public DateTime Data { get; set; }

        public string NomeAutor { get; set; }

        public string EmailAutor { get; set; }

        public string Texto { get; set; }
    }
}
