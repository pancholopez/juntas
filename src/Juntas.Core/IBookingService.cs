using System;

namespace Juntas.Core
{
    public interface IBookingService
    {
        Result Process(Reservation reservation);
    }

    public class MeetingSchedule
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }

    public interface IRoomLookupService
    {
        bool IsAvailable(MeetingSchedule schedule);
    }

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