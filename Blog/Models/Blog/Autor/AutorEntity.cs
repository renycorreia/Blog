using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Autor
{
    [Table ("autores")]
    public class AutorEntity
    {
        [Key]
        public int AutorId { get; set; }

        [MaxLength(100), Required]
        public string Nome { get; set; }
    }
}
