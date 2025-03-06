namespace ResFin.WebApi.Controllers.Residences
    {
    [ApiController]
    [Route("api/[controller]")]

    public class ResidenceController : ControllerBase
        {
        private readonly ISender _sender;

        public ResidenceController ( ISender sender )
            {
            _sender = sender;
            }

        [HttpGet]
        public async Task<IActionResult> SearchResidences (
            DateOnly beginDate,
            DateOnly EndDate,
            CancellationToken cancellationToken
            )
            {
            var query = new SearchResidencesQuery(beginDate, EndDate);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
            }
        }
    }
