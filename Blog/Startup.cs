using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Classificacao;
using Blog.Models.Blog.Postagem.Comentario;
using Blog.Models.ControleDeAcesso;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // Adicionar o servi�o do mecanismo de controle de acesso
            services.AddIdentity<Usuario, Papel>(options => 
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<DatabaseContext>();

            // Adicionar o servi�o do banco de dados
            services.AddDbContext<DatabaseContext>();

            // Adicionar os servi�os de ORM das entidades do dom�nio
            services.AddTransient<CategoriaOrmService>();
            services.AddTransient<PostagemOrmService>();
            services.AddTransient<AutorOrmService>();
            services.AddTransient<EtiquetaOrmService>();
            services.AddTransient<ClassificacaoOrmService>();
            services.AddTransient<ComentarioOrmService>();
            services.AddTransient<RevisaoOrmService>();
            services.AddTransient<PostagemEtiquetaOrmService>();

            // Adicionar os servi�os que possibilitam o funcionamento dos controllers e das views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //Mapeamento das rotas
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    */

                //Visitantes
                endpoints.MapControllerRoute(
                    name: "comum",
                    pattern: "/",
                    defaults: new { controller = "Home", action = "Index"});

                endpoints.MapControllerRoute(
                    name: "comentarios",
                    pattern: "comentarios/{action}/{id?}",
                    defaults: new { controller = "Comentarios", action = "Listar" });

                //Administradores
                endpoints.MapControllerRoute(
                    name: "admin.categorias",
                    pattern: "admin/categorias/{action}/{id?}",
                    defaults: new { controller = "AdminCategorias", action = "Listar"}
                    );

                endpoints.MapControllerRoute(
                    name: "admin.autores",
                    pattern: "admin/autores/{action}/{id?}",
                    defaults: new { controller = "AdminAutores", action = "Listar" });

                endpoints.MapControllerRoute(
                    name: "admin.etiquetas",
                    pattern: "admin/etiquetas/{action}/{id?}",
                    defaults: new { controller = "AdminEtiquetas", action = "Listar" });

                endpoints.MapControllerRoute(
                    name: "admin.postagens",
                    pattern: "admin/postagens/{action}/{id?}",
                    defaults: new { controller = "AdminPostagens", action = "Listar" });

            });
        }
    }
}
