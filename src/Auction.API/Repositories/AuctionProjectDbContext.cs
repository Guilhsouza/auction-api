using AuctionProject.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionProject.API.Repositories;

public class AuctionProjectDbContext : DbContext
{
    public AuctionProjectDbContext(DbContextOptions options): base(options) {  }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
