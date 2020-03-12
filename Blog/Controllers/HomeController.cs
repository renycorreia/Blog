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
            var dbContext = new DatabaseContext();

            //List<PostagemEntity> postagens = dbContext.postagens.ToList();
            List<PostagemEntity> postagens = dbContext.Postagens.Include(p => p.Categoria).Include(p => p.Revisao)
                .ToList();

            ViewBag.postagens = postagens;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
