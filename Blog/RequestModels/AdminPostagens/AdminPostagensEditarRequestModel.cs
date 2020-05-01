using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.AdminPostagens
{
    public class AdminPostagensEditarRequestModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int Versao { get; set; }

        public string Descricao { get; set; }

        public int IdAutor { get; set; }

        public int IdCategoria { get; set; }

        public DateTime ExibirAPartirDe { get; set; }
    }
}
