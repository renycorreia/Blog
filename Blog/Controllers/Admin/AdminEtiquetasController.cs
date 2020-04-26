using System;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.RequestModels.AdminEtiquetas;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers.Admin
{
    public class AdminEtiquetasController : Controller
    {
        private readonly EtiquetaOrmService _etiquetaOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;

        public AdminEtiquetasController(EtiquetaOrmService etiquetaOrmService, CategoriaOrmService categoriaOrmService)
        {
            _etiquetaOrmService = etiquetaOrmService;
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
        public RedirectToActionResult Criar(AdminEtiquetasCriarRequestModel request)
        {
            var nome = request.Nome;
            var idCategoria = request.IdCategoria;
            var categoria = _categoriaOrmService.ObterCategoriaPorId(idCategoria);

            try
            {
                _etiquetaOrmService.CriarEtiqueta(nome, categoria);
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
        public RedirectToActionResult Editar(AdminEtiquetasEditarRequestModel request)
        {   
            var id = request.Id;
            var nome = request.Nome;
            var idCategoria = request.IdCategoria;
            var categoria = _categoriaOrmService.ObterCategoriaPorId(idCategoria);

            try
            {
                _etiquetaOrmService.EditarEtiqueta(id, nome, categoria);
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
        public RedirectToActionResult Remover(AdminEtiquetasRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _etiquetaOrmService.RemoverEtiqueta(id);
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
