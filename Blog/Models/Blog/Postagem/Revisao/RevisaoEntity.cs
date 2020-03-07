using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao
{
    public class RevisaoEntity
    {
        [Key]
        public int CodRevisao { get; set; }
        public PostagemEntity PostagemRevisao { get; set; }

        [Required]
        public string TextoRevisao { get; set; }
        public int VersaoRevisao { get; set; }
        public DateTime DataRevisao { get; set; }
    }
}
