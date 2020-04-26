using System;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.RequestModels.AdminPostagens;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers.Admin
{
    public class AdminPostagensController : Controller
    {
        private readonly PostagemOrmService _postagemOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly AutorOrmService _autorOrmService;
        private readonly RevisaoOrmService _revisaoOrmService;

        public AdminPostagensController(PostagemOrmService postagemOrmService, CategoriaOrmService categoriaOrmService, AutorOrmService autorOrmService, RevisaoOrmService revisaoOrmService)
        {
            _postagemOrmService = postagemOrmService;
            _categoriaOrmService = categoriaOrmService;
            _autorOrmService = autorOrmService;
            _revisaoOrmService = revisaoOrmService;
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
        public RedirectToActionResult Criar(AdminPostagensCriarRequestModel request)
        {
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var idAutor = request.IdAutor;
            var idCategoria = request.IdCategoria;
            var exibirAPartirDe = request.ExibirAPartirDe;

            var autor = _autorOrmService.ObterAutorPorId(idAutor);
            var categoria = _categoriaOrmService.ObterCategoriaPorId(idCategoria);

            try
            {
                var postagem = _postagemOrmService.CriarPostagem(titulo, descricao, autor, categoria, exibirAPartirDe);

                _revisaoOrmService.CriarRevisao(descricao, 1, postagem, DateTime.Now);
            }
            catch (Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Criar");
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminPostagensEditarRequestModel request)
        {
            var id = request.Id;
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var idAutor = request.IdAutor;
            var idCategoria = request.IdCategoria;
            var exibirAPartirDe = request.ExibirAPartirDe;

            var autor = _autorOrmService.ObterAutorPorId(idAutor);
            var categoria = _categoriaOrmService.ObterCategoriaPorId(idCategoria);

            try
            {
                _postagemOrmService.EditarPostagem(id, titulo, descricao, autor, categoria, exibirAPartirDe);
            }
            catch (Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Editar", new { id = id });
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
        public RedirectToActionResult Remover(AdminPostagensRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _postagemOrmService.RemoverPostagem(id);
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
