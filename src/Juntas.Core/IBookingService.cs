namespace Juntas.Core
{
    public interface IBookingService
    {
        Result Process(Reservation reservation);
    }
}