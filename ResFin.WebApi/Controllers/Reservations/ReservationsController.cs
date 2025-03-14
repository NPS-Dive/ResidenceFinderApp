namespace ResFin.WebApi.Controllers.Reservations
    {
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ReservationsController : ControllerBase
        {
        private readonly ISender _sender;

        public ReservationsController ( ISender sender )
            {
            _sender = sender;
            }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation ( Guid id, CancellationToken cancellationToken )
            {
            var query = new GetReservationQuery(id);

            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess
                ? Ok(result.Value)
                : NotFound();
            }

            [HttpPost]
            public async Task<IActionResult> BookReservation(BookReservationRequest request,CancellationToken cancellationToken)
            {
                var command = new BookReservationCommand(
                    request.ResidenceId,
                    request.UserId,
                    request.BeginDate,
                    request.EndDate);

                var result = await _sender.Send(command, cancellationToken);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }

                return CreatedAtAction(nameof(GetReservation), new{id=result.Value}, result.Value);
            }
        }
    }
