using CleaningCompany.Application.CQRS.PriceLists.Commands.Create;
using CleaningCompany.Application.CQRS.PriceLists.Queries.GetAll;
using CleaningCompany.Application.CQRS.PriceLists.Queries.GetById;
using CleaningCompany.Application.CQRS.Services.Queries.GetAll;
using CleaningCompany.Contracts.PriceLists.Requests;
using CleaningCompany.Contracts.PriceLists.Responses;
using CleaningCompany.Contracts.Services.Responses;
using CleaningCompany.Domain.Common.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleaningCompany.MVC.Controllers;

[Authorize(Roles = "Admin, Worker")]
public sealed class PriceListsController : Controller
{
    private readonly ISender _sender;

    public PriceListsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var priceListsResult = await _sender.Send(new GetAllPriceListsQuery());
        return View(priceListsResult);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        Result<GetPriceListResponse> priceListResult = await _sender
            .Send(new GetPriceListByIdQuery(id));   

        return View(priceListResult);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        Result<List<GetAllServicesResponse>> servicesResult = await _sender
            .Send(new GetAllServicesQuery());
        return View(servicesResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePriceListRequest request)
    {
        Guid employeeId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        CreatePriceListCommand command =
            MapCreatePriceListRequestToCommand(request, User);

        var createResult = await _sender.Send(command);
        return Ok(createResult);
    }

    public static CreatePriceListCommand MapCreatePriceListRequestToCommand(CreatePriceListRequest request, ClaimsPrincipal user)
    {
        var positions = new List<CreatePriceListPositionCommand>();

        foreach (var positionRequest in request.Positions)
        {
            var positionCommand = new CreatePriceListPositionCommand(
                positionRequest.ServiceId,
                positionRequest.Price);

            positions.Add(positionCommand);
        }

        return new CreatePriceListCommand(user, positions);
    }
}
