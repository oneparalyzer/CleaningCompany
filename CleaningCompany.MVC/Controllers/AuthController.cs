using CleaningCompany.Application.CQRS.Users.Commands.Login;
using CleaningCompany.Application.CQRS.Users.Commands.Register;
using CleaningCompany.Contracts.Auth.Requests;
using CleaningCompany.Contracts.Users.Requests;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Infrastructure.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleaningCompany.MVC.Controllers;

public sealed class AuthController : Controller
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterClient(RegisterClientRequest request)
    {
        Result result = await _sender.Send(new RegisterCommand(
            request.Surname,
            request.Name,
            request.Patronymic,
            request.Email,
            request.UserName,
            request.Password,
            request.PasswordConfirm));

        return Ok(result);
    }

    [HttpGet]
    public IActionResult RegisterClient()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _sender.Send(new LoginCommand(
            request.UserName,
            request.Password,
            true));

        return Ok(result);
    }
}
