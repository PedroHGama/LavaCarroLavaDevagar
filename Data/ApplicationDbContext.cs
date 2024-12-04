using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WashCarLavaDevagar.Models;

namespace WashCarLavaDevagar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WashCarLavaDevagar.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<WashCarLavaDevagar.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<WashCarLavaDevagar.Models.Carro> Carro { get; set; } = default!;
        public DbSet<WashCarLavaDevagar.Models.TipoLavagem> TipoLavagem { get; set; } = default!;
        public DbSet<WashCarLavaDevagar.Models.Lavagem> Lavagem { get; set; } = default!;
    }
}
