using System;
using Blog.Models.Blog.Autor;
using Blog.RequestModels.AdminAutores;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers.Admin
{
    public class AdminAutoresController : Controller
    {
        private readonly AutorOrmService _categoriaOrmService;

        public AdminAutoresController(AutorOrmService categoriaOrmService)
        {
            _categoriaOrmService = categoriaOrmService;
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
        public RedirectToActionResult Criar(AdminAutoresCriarRequestModel request)
        {
            var nome = request.Nome;

            try
            {
                _categoriaOrmService.CriarAutor(nome);
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
        public RedirectToActionResult Editar(AdminAutoresEditarRequestModel request)
        {
            var nome = request.Nome;
            var id = request.Id;

            try
            {
                _categoriaOrmService.EditarAutor(id, nome);
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
        public RedirectToActionResult Remover(AdminAutoresRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _categoriaOrmService.RemoverAutor(id);
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
