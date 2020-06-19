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

            services.AddDbContext<DataContext>(options => options.UseNpgsql("Server=ec2-54-147-209-121.compute-1.amazonaws.com;Database=da30ffl7k6kfii;User ID=xasjzyuhjkzbis;Password=81ceb1d804e02fbd4937944168e53f19a3b5426bc99cc9a3c48d5f4840952243;"));
            //services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("ComercioLocalDB"));

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

            app.UseCors( option =>
                option.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
