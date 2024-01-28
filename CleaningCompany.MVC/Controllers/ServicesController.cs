using CleaningCompany.Application.CQRS.Services.Commands.Create;
using CleaningCompany.Application.CQRS.Services.Commands.Remove;
using CleaningCompany.Application.CQRS.Services.Commands.Update;
using CleaningCompany.Application.CQRS.Services.Queries.GetAll;
using CleaningCompany.Contracts.Services.Requests;
using CleaningCompany.Contracts.Services.Responses;
using CleaningCompany.Domain.Common.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleaningCompany.MVC.Controllers;

[Authorize(Roles = "Admin")]
public sealed class ServicesController : Controller
{
    private readonly ISender _sender;

    public ServicesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        Result<List<GetAllServicesResponse>> result = await _sender
            .Send(new GetAllServicesQuery());

        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateServiceRequest request)
    {
        Result result = await _sender
            .Send(new CreateServiceCommand(request.Title));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Remove([FromRoute] Guid id)
    {
        Result result = await _sender
            .Send(new RemoveServiceCommand(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateServiceRequest request)
    {
        Result result = await _sender
            .Send(new UpdateServiceCommand(request.ServiceId, request.NewTitle));

        return Ok(result);
    }
}
