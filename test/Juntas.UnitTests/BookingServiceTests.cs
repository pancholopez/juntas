using Juntas.Core;
using Moq;
using Xunit;

namespace Juntas.UnitTests
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

    public class BookingServiceTests
    {
        private readonly BookingServiceBuilder _serviceBuilder;

        public BookingServiceTests()
        {
            _serviceBuilder = new BookingServiceBuilder();
        }

        [Fact]
        public void Process_AllOk_ReservationIsSuccess()
        {
            var service = _serviceBuilder.Build();
            var reservation = new Reservation();

            var result = service.Process(reservation);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Process_OverlappingAppointment_ShouldFail()
        {
            var service = _serviceBuilder.WithNoRoomsAvailable().Build();

            var result = service.Process(new Reservation());

            Assert.True(result.IsFailure);
            Assert.Equal("Meeting Overlap", result.Error);
        }
    }
}
