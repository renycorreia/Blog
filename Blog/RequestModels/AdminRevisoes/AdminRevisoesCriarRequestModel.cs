using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.AdminRevisoes
{
    public class AdminRevisoesCriarRequestModel
    {
        public int IdPostagem { get; set; }

        public string Texto { get; set; }

        public int Versao { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
