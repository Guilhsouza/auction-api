using AuctionProject.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionProject.API.Repositories;

public class AuctionProjectDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\guied\OneDrive\Área de Trabalho\Estudos Programação\NLW-C#\leilaoDbNLW.db");
    }
}
