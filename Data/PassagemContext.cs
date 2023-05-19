using FlightForYou.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightForYou.API.Data
{
    public class PassagemContext : DbContext 
    {
        public PassagemContext(DbContextOptions<PassagemContext> opts )
            : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Passagem>().HasKey(passagem => new {passagem.Id});   
        }

        public DbSet<Passagem> Passagens { get; set; }
    }
}
