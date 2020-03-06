using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Autor
{
    public class AutorEntity
    {

        [Key]
        public int codAutor { get; set; }

        [MaxLength(100), Required]
        public string nomeAutor { get; set; }
    }
}
