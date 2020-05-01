using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ControleDeAcesso
{
    public class Usuario : IdentityUser<int>
    {
        public String Apelido { get; set; }
    }
}
