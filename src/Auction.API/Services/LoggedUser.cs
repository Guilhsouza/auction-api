using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;

namespace AuctionProject.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;

    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAccessor = httpContext;
        _repository = repository;
    }

    public User User() 
    {
        var token = TokenOnRequest();
        var email = FromBase64ToString(token);

        return _repository.GetUserByEmail(email);
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
