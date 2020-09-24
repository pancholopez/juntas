using Juntas.Core;
using Moq;

namespace Juntas.UnitTests.Core
{
    internal class BookingServiceBuilder
    {
        private IRoomLookupService _roomLookupService;

        public BookingServiceBuilder()
        {
            SetRoomAvailable(true);
        }

        public void SetRoomAvailable(bool isAvailable)
        {
            var mock = new Mock<IRoomLookupService>();
            mock.Setup(x => x.IsAvailable(It.IsAny<MeetingSchedule>())).Returns(isAvailable);
            _roomLookupService = mock.Object;
        }

        public BookingServiceBuilder WithNoRoomsAvailable()
        {
            SetRoomAvailable(false);
            return this;
        }

        public IBookingService Build()
        {
            return new BookingService(_roomLookupService);
        }
    }
}