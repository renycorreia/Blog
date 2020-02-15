using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        public string TituloPost;
        public AutorEntity AutorPost; //using Blog.Models.Blog.Autor;
        public CategoriaEntity CategoriaPost; //using Blog.Models.Blog.Categoria;
         
        public virtual string editar() //virtual: método pode ser sobreescrito por qualquer um que herdar essa classe
        {
            return "edição realizada";

        }
    }

    public class PostagemSobreFilmesEntity : PostagemEntity //herança
    {
        public string GeneroPSF;

        public override string editar() //override: indica que o método da classe mãe foi sobreescrito
        {
            return "edição realizada na postagem sobre filmes";
        }
    }
}

//FQCN: FULLY QUALIFIED CLASS NAME (NAMESPACE DA CLASSE + NOME DA CLASSE) 
//Blog.Models.Blog.Postagem.PostagemEntity

//classe é a definição de um tipo
//objetos são as instancias da classe
/*
    os três pilares da class: 
        empsulamento: proteger (define se um atributo/propriedade está protegido de alteração e acesso);
            public: pode ser alterada a qualquer momento;
            private: não pode alterar a propriedade;
            protected: 
        herança: uma classe receber propriedades e métodos de outra classe (ex.: PostagemSobreFilmesEntity)
        polimofismo: sobreescrita e sobrecarga de métodos
            sobreescrita: método com mesmo parametro, com conteúdo diferente
            sobrecarga: métodos com mesmo nome, com parametros diferentes
*/

//Composição: fazer com que uma classe dependa da outra (importar a classe: using nameSpace de autor, nameSpace de categoria...)