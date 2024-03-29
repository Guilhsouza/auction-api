﻿using AuctionProject.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuctionProject.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly IUserRepository _repository;

    public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository;
   
    public void OnAuthorization(AuthorizationFilterContext context)
    {
       try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64ToString(token);

            var exist = _repository.ExistUserWithEmail(email);

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("Email is not valid!");
            }
        }
        catch (Exception ex) 
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var Authentication = context.Request.Headers.Authorization.ToString();
        
        if(string.IsNullOrEmpty(Authentication))
        {
            throw new Exception("token is missing!");
        }

        return Authentication["Bearer ".Length..];
    }

    private string FromBase64ToString(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
