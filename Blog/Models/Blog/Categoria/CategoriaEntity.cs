using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Categoria
{
    public class CategoriaEntity
    {
        [Key]
        public int codCategoria { get; set; }

        [MaxLength(100), Required]
        public string nomeCategoria { get; set; }


    }
}
