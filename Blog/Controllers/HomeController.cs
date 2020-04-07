﻿using System;
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
using Blog.ViewModels.Home;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Postagem.Classificacao;
using Blog.Models.Blog.Postagem.Comentario;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly PostagemOrmService _postagemOrmService;
        private readonly AutorOrmService _autorOrmService;
        private readonly EtiquetaOrmService _etiquetaOrmService;
        private readonly ClassificacaoOrmService _classificacaoOrmService;
        private readonly ComentarioOrmService _comentarioOrmService;
        private readonly RevisaoOrmService _revisaoOrmService;
        private readonly PostagemEtiquetaOrmService _postagemEtiquetaOrmService;

        public HomeController(
            ILogger<HomeController> logger
            , CategoriaOrmService categoriaOrmService
            , PostagemOrmService postagemOrmService
            , AutorOrmService autorOrmService
            , EtiquetaOrmService etiquetaOrmService
            , ClassificacaoOrmService classificacaoOrmService
            , ComentarioOrmService comentarioOrmService
            , RevisaoOrmService revisaoOrmService
            , PostagemEtiquetaOrmService postagemEtiquetaOrmService

        ){
            _logger = logger;
            _categoriaOrmService = categoriaOrmService;
            _postagemOrmService = postagemOrmService;
            _autorOrmService = autorOrmService;
            _etiquetaOrmService = etiquetaOrmService;
            _classificacaoOrmService = classificacaoOrmService;
            _comentarioOrmService = comentarioOrmService;
            _revisaoOrmService = revisaoOrmService;
            _postagemEtiquetaOrmService = postagemEtiquetaOrmService;
        }

        public IActionResult Index()
        {
            // Instanciar a ViewModel relativa à action
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.TituloPagina = "Página Home";

            List<PostagemEntity> listaPostagens = _postagemOrmService.ObterPostagens();

            foreach (PostagemEntity postagem in listaPostagens)
            {
                PostagemHomeIndex postagemHomeIndex = new PostagemHomeIndex();
                postagemHomeIndex.Titulo = postagem.Titulo;
                postagemHomeIndex.Descricao = postagem.Descricao;
                postagemHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemHomeIndex.NumeroComentarios = postagem.Comentarios.Count.ToString();
                postagemHomeIndex.PostagemId = postagem.Id.ToString();

                // Obter última revisão
                RevisaoEntity ultimaRevisao = postagem.Revisoes.OrderByDescending(o => o.DataCriacao).FirstOrDefault();
                if (ultimaRevisao !=null)
                {
                    postagemHomeIndex.Data = ultimaRevisao.DataCriacao.ToLongDateString();
                }

                model.Postagens.Add(postagemHomeIndex);
                }

            // Alimentar a lista de categorias que serão exibidas na view
            List<CategoriaEntity> listaCategorias = _categoriaOrmService.ObterCategorias();

            foreach (CategoriaEntity categoria in listaCategorias)
            {
                CategoriaHomeIndex categoriaHomeIndex = new CategoriaHomeIndex();
                categoriaHomeIndex.Nome = categoria.Nome;
                categoriaHomeIndex.CategoriaId = categoria.Id.ToString();

                model.Categorias.Add(categoriaHomeIndex);

                // Alimentar a lista de etiquetas que serão exibidas na view, a partir das etiquetas da categoria
                foreach (EtiquetaEntity etiqueta in categoria.Etiquetas)
                {
                    EtiquetaHomeIndex etiquetaHomeIndex = new EtiquetaHomeIndex();
                    etiquetaHomeIndex.Nome = etiqueta.Nome;
                    etiquetaHomeIndex.EtiquetaId = etiqueta.Id.ToString();
                
                    model.Etiquetas.Add(etiquetaHomeIndex);
                }
            }


            // Alimentar a lista de postagens populares que serão exibidas na view
            // TODO Obter lista de postagens populares

             List<PostagemEntity> listaPostagensPopulaes = _postagemOrmService.ObterPostagensPopulares();

            foreach (PostagemEntity postagemPopular in listaPostagensPopulaes)
            {
                PostagemPopularHomeIndex postagemPopularHomeIndex = new PostagemPopularHomeIndex();

                postagemPopularHomeIndex.Titulo = postagemPopular.Titulo;
                postagemPopularHomeIndex.PostagemId = postagemPopular.Id.ToString();
                postagemPopularHomeIndex.Categoria = postagemPopular.Categoria.Nome;

                model.PostagensPopulares.Add(postagemPopularHomeIndex);
            }

            
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
