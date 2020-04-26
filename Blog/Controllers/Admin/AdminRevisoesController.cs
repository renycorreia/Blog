using System;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.RequestModels.AdminPostagens;
using Blog.RequestModels.AdminRevisoes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers.Admin
{
    public class AdminRevisoesController : Controller
    {
        private readonly RevisaoOrmService _revisaoOrmService;
        private readonly PostagemOrmService _postagemOrmService;

        public AdminRevisoesController(RevisaoOrmService revisaoOrmService, PostagemOrmService postagemOrmService)
        {
            _revisaoOrmService = revisaoOrmService;
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
        public RedirectToActionResult Criar(AdminRevisoesCriarRequestModel request)
        {
            var idPostagem = request.IdPostagem;
            var texto = request.Texto;
            var versao = request.Versao;
            var dataCriacao = request.DataCriacao;

            var postagem = _postagemOrmService.ObterPostagemPorId(idPostagem);

            try
            {
                _revisaoOrmService.CriarRevisao(texto, versao, postagem, dataCriacao);
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
        public RedirectToActionResult Editar(AdminRevisoesEditarRequestModel request)
        {
            var id = request.Id;
            var idPostagem = request.IdPostagem;
            var texto = request.Texto;
            var versao = request.Versao;
            var dataCriacao = request.DataCriacao;

            var postagem = _postagemOrmService.ObterPostagemPorId(idPostagem);

            try
            {
                _revisaoOrmService.EditarRevisao(id, texto, versao, postagem, dataCriacao);
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
        public RedirectToActionResult Remover(AdminRevisoesRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _revisaoOrmService.RemoverRevisao(id);
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
