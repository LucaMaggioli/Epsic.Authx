using Epsic.Authx.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Epsic.Authx.Data
{
    // Microsoft ASP.NET Core Identity va implémenter pour nous la gestion des users, roles, tokens
    // Pour cela 
    public class CovidDbContext : IdentityDbContext
    {
        public DbSet<TestCovid> TestsCovid { get; set; }

        public CovidDbContext(DbContextOptions<CovidDbContext> options) : base(options)
        {

        }
    }
}
