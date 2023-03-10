using Cadastro_Clientes___Back_end.Data;
using Cadastro_Clientes___Back_end.Repositories;
using Cadastro_Clientes___Back_end.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_Clientes___Back_end
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => {
                options.AddPolicy("MyAllowedOrigins",
                policy => {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            ;

            var connection = builder.Configuration["ConnectionStrings:Database"];
            builder.Services.AddDbContext<PessoaDBContext>(
                    options => options.UseMySql(connection, new MySqlServerVersion(new Version(8,0,29))));


            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); 
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

    
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyAllowedOrigins");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}