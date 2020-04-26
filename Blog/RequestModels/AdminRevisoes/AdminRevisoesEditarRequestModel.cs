using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.AdminRevisoes
{
    public class AdminRevisoesEditarRequestModel
    {
        public int Id { get; set; }

        public int IdPostagem { get; set; }

        public string Texto { get; set; }

        public int Versao { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
