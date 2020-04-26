using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Comentario;
using Blog.RequestModels.Comentarios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers.Visitante
{
    public class ComentariosController : Controller
    {
        private readonly ComentarioOrmService _comentarioOrmService;
        private readonly PostagemOrmService _postagemOrmService;

        public ComentariosController(ComentarioOrmService comentarioOrmService, PostagemOrmService postagemOrmService)
        {
            _comentarioOrmService = comentarioOrmService;
            _postagemOrmService = postagemOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult Detalhar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Criar(ComentariosCriarRequestModel request)
        {
            var texto = request.Texto;
            var autor = request.Autor;
            var idPostagem = request.IdPostagem;
            var datacriacao = DateTime.Now;
            var idComentarioPai = request.IdComentarioPai;

            var postagem = _postagemOrmService.ObterPostagemPorId(idPostagem);
            var comentarioPai = _comentarioOrmService.ObterComentarioPorId(idComentarioPai);

            try
            {
                var comentario = _comentarioOrmService.CriarComentario(postagem, texto, autor, datacriacao, comentarioPai);
            }
            catch (Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Criar");
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];


            return View();
        }

        [HttpPost]
        public RedirectToActionResult Remover(ComentariosRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _comentarioOrmService.RemoverComentario(id);
            }
            catch (Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Remover", new { id = id });
            }

            return RedirectToAction("Listar");
        }

    }
}