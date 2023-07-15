using Microsoft.AspNetCore.Mvc;
using Newme.Payment.Application.InputModels;
using Newme.Payment.Application.Services;

namespace Newme.Payment.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{version:apiVersion}/payment")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _application;

    public PaymentController(IPaymentService application)
    {
        _application = application; 
    }

    [HttpPost("credit-card")]
    public async Task<IActionResult> AdRegisterCreditCardPaymentd(RegisterCreditCardPaymentInputModel inputModel)
    {
        var result = await _application.RegisterCreditCardPayment(inputModel);
        return NoContent();
    }

    [HttpPost("debit-card")]
    public async Task<IActionResult> ARegisterDebitCardPaymentdd(RegisterDebitCardPaymentInputModel inputModel)
    {
        var result = await _application.RegisterDebitCardPayment(inputModel);
        return NoContent();
    }

    [HttpPost("pix")]
    public async Task<IActionResult> RegisterPixPayment(RegisterPixPaymentInputModel inputModel)
    {
        var result = await _application.RegisterPixPayment(inputModel);
        return NoContent();
    }

    [HttpPost("change-status")]
    public async Task<IActionResult> ChangeStatus(ChangePaymentStatusInputModel inputModel)
    {
        var result = await _application.ChangeStatus(inputModel);
        return NoContent();
    }
}
