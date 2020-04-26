using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.Comentarios
{
    public class ComentariosCriarRequestModel
    {
        public string Texto { get; set; }

        public string Autor { get; set; }

        public DateTime DataCriacao { get; set; }

        public int IdComentarioPai { get; set; }

        public int IdPostagem { get; set; }

    }
}
