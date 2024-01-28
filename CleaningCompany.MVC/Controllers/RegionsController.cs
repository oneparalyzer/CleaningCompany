using CleaningCompany.Application.CQRS.Regions.Commands.Create;
using CleaningCompany.Application.CQRS.Regions.Commands.Remove;
using CleaningCompany.Application.CQRS.Regions.Commands.Update;
using CleaningCompany.Application.CQRS.Regions.Queries.GetAll;
using CleaningCompany.Application.CQRS.Services.Commands.Create;
using CleaningCompany.Application.CQRS.Services.Commands.Remove;
using CleaningCompany.Application.CQRS.Services.Commands.Update;
using CleaningCompany.Application.CQRS.Services.Queries.GetAll;
using CleaningCompany.Contracts.Regions.Requests;
using CleaningCompany.Contracts.Regions.Responses;
using CleaningCompany.Contracts.Services.Requests;
using CleaningCompany.Contracts.Services.Responses;
using CleaningCompany.Domain.Common.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleaningCompany.MVC.Controllers;

[Authorize(Roles = "Admin")]
public sealed class RegionsController : Controller
{
    private readonly ISender _sender;

    public RegionsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        Result<List<GetAllRegionsResponse>> result = await _sender
            .Send(new GetAllRegionsQuery());

        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegionRequest request)
    {
        Result result = await _sender
            .Send(new CreateRegionCommand(request.Title));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Remove([FromRoute] Guid id)
    {
        Result result = await _sender
            .Send(new RemoveRegionCommand(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateRegionRequest request)
    {
        Result result = await _sender
            .Send(new UpdateRegionCommand(request.RegionId, request.NewTitle));

        return Ok(result);
    }
}
