using Cadastro_Clientes___Back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_Clientes___Back_end.Data
{
    public class PessoaDBContext : DbContext
    {
        public PessoaDBContext(DbContextOptions<PessoaDBContext> options)
            :base(options)
        {

        }

        public DbSet<PessoaModel> Pessoas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
