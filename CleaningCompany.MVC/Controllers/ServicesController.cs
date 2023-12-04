using CleaningCompany.Application.CQRS.Services.Commands.Create;
using CleaningCompany.Application.CQRS.Services.Queries;
using CleaningCompany.Contracts.Services.Requests;
using CleaningCompany.Contracts.Services.Responses;
using CleaningCompany.Domain.AggregateModels.UserAggregate.Enums;
using CleaningCompany.Domain.Common.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleaningCompany.MVC.Controllers;

public class ServicesController : Controller
{
    private readonly ISender _sender;

    public ServicesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        Result<IEnumerable<GetAllServicesResponse>> result = await _sender
            .Send(new GetAllServicesQuery());

        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Guidd()
    {
        return Json(new
        {
            val = Guid.NewGuid()
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateServiceRequest request)
    {
        Result result = await _sender
            .Send(new CreateServiceCommand(request.Title));

        return Json(result);
    }
}
