using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;

namespace AuctionProject.API.Repositories.DataAcess;

public class UserRepository : IUserRepository
{
    private readonly AuctionProjectDbContext _dbContext;

    public UserRepository(AuctionProjectDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(Users => Users.Email.Equals(email));
    }

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}
