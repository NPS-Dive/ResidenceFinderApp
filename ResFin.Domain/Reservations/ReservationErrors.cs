namespace ResFin.Domain.Residences.Events.Reservations;

public static class ReservationErrors
{
    public static Error NotFound = new(
        "Reservation.NotFound",
        "This reservation with the specified ID was not found!"
        );

    public static Error AlreadyBegun = new(
        "Reservation.AlreadyBegun",
        "This reservation has been already begun!"
    );

    public static Error NotReserved = new(
        "Reservation.NotReserved",
        "This reservation has not been booked!"
    );

    public static Error Overlap = new(
        "Reservation.Overlap",
        "This reservation is overlapping wi another existing reservation"
    );

    public static Error NotConfirmed = new(
        "Reservation.NotConfirmed",
        "unfortunately, this reservation was not confirmed!"
    );

    public static Error NotCompeleted = new(
        "Reservation.NotCompeleted",
        "This reservation is not completed yet!"
    );


    }