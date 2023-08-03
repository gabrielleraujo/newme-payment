using System.Net;
using FluentValidation.Results;
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
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> RegisterCreditCardPaymentd(RegisterCreditCardPaymentInputModel inputModel)
    {
        var response = await _application.RegisterCreditCardPayment(inputModel);
        return response.Errors.Count == 0 ? Ok() : BadRequest(response);
    }

    [HttpPost("debit-card")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> RegisterDebitCardPaymentdd(RegisterDebitCardPaymentInputModel inputModel)
    {
        var response = await _application.RegisterDebitCardPayment(inputModel);
        return response.Errors.Count == 0 ? Ok() : BadRequest(response);
    }

    [HttpPost("pix")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> RegisterPixPayment(RegisterPixPaymentInputModel inputModel)
    {
        var response = await _application.RegisterPixPayment(inputModel);
        return response.Errors.Count == 0 ? Ok() : BadRequest(response);
    }

    [HttpPost("change-status")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ChangeStatus(ChangePaymentStatusInputModel inputModel)
    {
        var response = await _application.ChangeStatus(inputModel);
        return response.Errors.Count == 0 ? NoContent() : BadRequest(response);
    }
}
