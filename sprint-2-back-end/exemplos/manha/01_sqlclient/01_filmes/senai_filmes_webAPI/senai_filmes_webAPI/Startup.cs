using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                // Define a forma de autenticação
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os parâmetros de validação do token
                .AddJwtBearer("JwtBearer", options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Será validado o emissor do token
                        ValidateIssuer = true,

                        // Será validado o destinatário do token
                        ValidateAudience = true,

                        // Será validado o tempo de vida do token
                        ValidateLifetime = true,

                        // Define a chave de segurança
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),

                        // Tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(40),

                        // Nome do isser, ou seja, quem gerou o token
                        ValidIssuer = "Filmes.webAPI",

                        // Nome do audience, ou seja, para quem se destina a validação do token
                        ValidAudience = "Filmes.webAPI"
                    };
                });                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Habilita a autenticação
            app.UseAuthentication();    // 401

            // Habilita a autorização
            app.UseAuthorization();     // 403

            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento dos Controllers.
                endpoints.MapControllers();
            });
        }
    }
}
