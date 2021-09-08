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
                // Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os par�metros de valida��o do token
                .AddJwtBearer("JwtBearer", options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Valida quem est� emitindo o token
                        ValidateIssuer = true,

                        // Valida quem est� recebendo o token
                        ValidateAudience = true,

                        // Valida o tempo de expira��o do token
                        ValidateLifetime = true,

                        // Definindo a chave (frase) de seguran�a
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),

                        // Tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Define o nome do issuer, ou seja, quem emite o token
                        ValidIssuer = "Filmes.webAPI",

                        // Define o nome do audience, ou seja, quem recebe o token
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

            // Habilita a autentica��o
            app.UseAuthentication();        // 401
            
            // Habilita a autoriza��o
            app.UseAuthorization();         // 403

            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento dos Controllers.
                endpoints.MapControllers();
            });
        }
    }
}
