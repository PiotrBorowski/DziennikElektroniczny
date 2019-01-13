using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;
using DziennikElektroniczny.Services.AdminService;
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
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, Uzytkownik>, UzytkownikRepo>();
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, Klasa>, KlasaRepo>();
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, Uczen>, UczenRepo>();
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, PlanLekcji>, PlanLekcjiRepo>();
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna>, JednostkaLekcyjnaRepo>();
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, Przedmiot>, PrzedmiotRepo>();
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, Ocena>, OcenaRepo>();
            services.AddScoped<GenericRepository<DziennikElektronicznyContext, Wiadomosc>, WiadomoscRepo>();
            services.AddScoped < GenericRepository < DziennikElektronicznyContext, Uwaga >, UwagaRepo>();
            services.AddScoped < GenericRepository <DziennikElektronicznyContext, Obecnosc>, ObecnoscRepo>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ITeacherService, TeacherService>();


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
