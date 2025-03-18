using Asp.Versioning;
using Asp.Versioning.Builder;

namespace ResFin.WebApi.Controllers.Reservations
    {
    // [Authorize]
    //  [ApiController]
    //[ApiVersion(ApiVersions.V2)]
    //  [Route("api/[controller]/v{version:apiVersion}/[action]")]

    public static class ReservationsEndPoints
        {
        public static IEndpointRouteBuilder MapReservationEndPoints ( this IEndpointRouteBuilder builder )
            {
            
            builder
                .MapGet("Reservations/{id}", GetReservation)
                .RequireAuthorization()
                .WithName(nameof(GetReservation));

            builder
                .MapPost("Reservations/", BookReservation)
                .RequireAuthorization();

            return builder;
            }



        public static async Task<IResult> GetReservation (
            Guid id,
            ISender sender,
            CancellationToken cancellationToken )
            {
            var query = new GetReservationQuery(id);

            var result = await sender.Send(query, cancellationToken);
            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.NotFound();
            }


        public static async Task<IResult> BookReservation (
            BookReservationRequest request,
            ISender sender,
            CancellationToken cancellationToken )
            {
            var command = new BookReservationCommand(
                request.ResidenceId,
                request.UserId,
                request.BeginDate,
                request.EndDate);

            var result = await sender.Send(command, cancellationToken);
            if (result.IsFailure)
                {
                return Results.BadRequest(result.Error);
                }

            return Results.CreatedAtRoute(nameof(GetReservation), new { id = result.Value }, result.Value);
            }
        }
    }
