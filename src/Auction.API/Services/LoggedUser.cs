using AuctionProject.API.Entities;
using AuctionProject.API.Repositories;

namespace AuctionProject.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedUser(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }

    public User User() 
    {
        var repository = new AuctionProjectDbContext();

        var token = TokenOnRequest();
        var email = FromBase64ToString(token);

        return repository.Users.First(user => user.Email.Equals(email));
    }

    private string TokenOnRequest()
    {
        var Authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return Authentication["Bearer ".Length..];
    }

    private string FromBase64ToString(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
