namespace Juntas.Core
{
    public class BookingService : IBookingService
    {
        private readonly IRoomLookupService _roomLookupService;

        public BookingService(IRoomLookupService roomLookupService)
        {
            _roomLookupService = roomLookupService;
        }

        public Result Process(Reservation reservation)
        {
            if (!_roomLookupService.IsAvailable(reservation.Schedule)) return Result.Fail("Meeting Overlap");
            return Result.Ok();
        }
    }
}