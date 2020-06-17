using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercioLocalBackEnd.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace ComercioLocalBackEnd
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            var key = Encoding.ASCII.GetBytes("UmTokenMuitoGrandeEDiferenteParaNinguemDescobrir");

            services.AddControllers();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>{
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            //TODO COLOCAR BANCO HEROKU
            //string strConn = Configuration.GetConnectionString("ComercioLocalDB"); 
            // services.AddDbContext<DataContext>(options => options.UseSqlServer(strConn));
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("ComercioLocalDB"));

            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPromocaoRepository, PromocaoRepository>();
            //services.AddTransient<PerfilHandler, PerfilHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
