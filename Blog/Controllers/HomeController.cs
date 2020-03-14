using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Models.Blog.Postagem;
using Microsoft.EntityFrameworkCore;
using Blog.Models.Blog.Categoria;
using Blog.ViewModels;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisao;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DatabaseContext dbContext = new DatabaseContext();

            HomeIndexViewModel model = new HomeIndexViewModel();

            List<PostagemEntity> listaPostagens = dbContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisao)
                .Include(p => p.Comentario)
                .ToList();

            foreach (PostagemEntity postagem in listaPostagens)
            {
                PostagemHomeIndex postagemHomeIndex = new PostagemHomeIndex();
                postagemHomeIndex.Titulo = postagem.Titulo;
                //postagemHomeIndex.Descricao = postagem.Descricao; ??? não tem descrição na postagem
                postagemHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemHomeIndex.NumeroComentarios = postagem.Comentario.Count.ToString();
                postagemHomeIndex.PostagemId = postagem.PostagemId.ToString();

                RevisaoEntity ultimaRevisao = postagem.Revisao.OrderByDescending(o => o.DataCriacao);
                if (ultimaRevisao !=null)
                {
                    //PostagemHomeIndex.Data = ultimaRevisao.DataCriacao
                }


            }

            ViewBag.postagens = listaPostagens;

            List<EtiquetaEntity> listaEtiquetas = dbContext.Etiquetas.ToList();
            foreach (EtiquetaEntity etiqueta in listaEtiquetas)
            {
                Etiqueta 
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
