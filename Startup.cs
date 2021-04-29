using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Turnos.Models;

namespace Turnos
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
            //para establecer un middleware para el manejo de la sesion
            // y le establecemos las propiedades
            //option.Cookie.HttpOnly = true; almacena la cookie en el navegador, no es equipo del usuario
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(300);
                option.Cookie.HttpOnly = true;
            });

            services.AddControllersWithViews(options =>
                //en vez de agregar ValidateAntiForgeryToken a todos los metodos post
                //implementamos este middleware que se encarga de validar todos los meotodos de tipo POST
                //quueda la validacion Global
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            //creamos la conexion a la BD Sql, donde le especificamos el contexto de nuestr abd
            // => igual operador lamda , define opciones como parametro
            //Le pasamos el string de conexion de sql server, a su vez el eobjeto opciones que se crea en el momento sin nombre bajo el operador lamda
            //se la embiamos al metodo AddDbContext y todo este metodo configura la conexion de sql y a su vez inyecta el servicio en nuestro contenedor (inyeccion de dependencias)            
            services.AddDbContext<TurnosContext>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("TurnosContext")));
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
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            //Estable cual es el controlador por default y patron para abrirlo
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
