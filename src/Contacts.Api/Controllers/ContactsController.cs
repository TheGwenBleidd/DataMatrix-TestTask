using Contacts.Application.BusinessLogic.Contacts.Commands.Create;
using Contacts.Application.BusinessLogic.Contacts.Commands.Delete;
using Contacts.Application.BusinessLogic.Contacts.Commands.Update;
using Contacts.Application.BusinessLogic.Contacts.Queries.GetById;
using Contacts.Application.BusinessLogic.Contacts.Queries.GetPaginated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Api.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
public class ContactsController : Controller
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command, CancellationToken cancellationToken)
    {
        var contactId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetContact), new { id = contactId }, contactId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletContact([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteContactCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContact(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetContactQuery(id), cancellationToken));
    }

    [HttpGet("paginated")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContactsPaginated([FromQuery] GetContactsPaginatedQuery query, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }
}