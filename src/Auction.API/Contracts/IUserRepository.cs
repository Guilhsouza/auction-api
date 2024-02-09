using AuctionProject.API.Entities;

namespace AuctionProject.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
