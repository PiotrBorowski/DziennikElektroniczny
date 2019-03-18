using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;
using DziennikElektroniczny.Services.AdminService;
using DziennikElektroniczny.Services.ParentService;
using DziennikElektroniczny.Services.TeacherService;
using DziennikElektroniczny.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DziennikElektroniczny
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DziennikElektronicznyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddCors();
            services.AddAutoMapper();
            services.AddScoped<IGenericRepository<Uzytkownik>, GenericRepository<DziennikElektronicznyContext, Uzytkownik>>();
            services.AddScoped<IGenericRepository<Klasa>, GenericRepository<DziennikElektronicznyContext, Klasa>>();
            services.AddScoped<IGenericRepository<Uczen>, GenericRepository<DziennikElektronicznyContext, Uczen>>();
            services.AddScoped<IGenericRepository<PlanLekcji>, GenericRepository<DziennikElektronicznyContext, PlanLekcji>>();
            services.AddScoped<IGenericRepository<JednostkaLekcyjna>, GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna>>();
            services.AddScoped<IGenericRepository<Przedmiot>, GenericRepository<DziennikElektronicznyContext, Przedmiot>>();
            services.AddScoped<IGenericRepository<Ocena>, GenericRepository<DziennikElektronicznyContext, Ocena>>();
            services.AddScoped<IGenericRepository<Wiadomosc>, GenericRepository<DziennikElektronicznyContext, Wiadomosc>>();
            services.AddScoped<IGenericRepository<Uwaga >, GenericRepository<DziennikElektronicznyContext, Uwaga>>();
            services.AddScoped<IGenericRepository<Obecnosc>, GenericRepository<DziennikElektronicznyContext, Obecnosc>>();
            services.AddScoped<IGenericRepository<Lekcja>, GenericRepository<DziennikElektronicznyContext, Lekcja>>();
            services.AddScoped<IGenericRepository<ListaObecnosci>, GenericRepository<DziennikElektronicznyContext, ListaObecnosci>>();
            services.AddScoped<IGenericRepository<Usprawiedliwienie>, GenericRepository<DziennikElektronicznyContext, Usprawiedliwienie>>();



            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IParentService, ParentService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
