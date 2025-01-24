using CQRSNight.MediatorDesignPattern.Commands;
using CQRSNight.MediatorDesignPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSNight.Controllers;
public class CustomerController : Controller
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> CustomerList()
    {
        var values = await _mediator.Send(new GetCustomerQuery());
        return View(values);
    }

    public IActionResult CreateCustomer()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
    {
        await _mediator.Send(command);
        return RedirectToAction("CustomerList");
    }

    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await _mediator.Send(new RemoveCustomerCommand(id));
        return RedirectToAction("CustomerList");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCustomer(int id)
    {
        var value = await _mediator.Send(new GetCustomerByIdQuery(id));
        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
    {
        await _mediator.Send(command);
        return RedirectToAction("CustomerList");
    }
}
