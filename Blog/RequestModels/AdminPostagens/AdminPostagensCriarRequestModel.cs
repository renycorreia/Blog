using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.AdminPostagens
{
    public class AdminPostagensCriarRequestModel
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int IdAutor { get; set; }

        public int IdCategoria { get; set; }

        public DateTime ExibirAPartirDe { get; set; }

    }
}
