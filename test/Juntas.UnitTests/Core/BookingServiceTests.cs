using Juntas.Core;
using Xunit;

namespace Juntas.UnitTests.Core
{
    public class BookingServiceTests
    {
        private readonly BookingServiceBuilder _serviceBuilder;

        public BookingServiceTests()
        {
            _serviceBuilder = new BookingServiceBuilder();
        }

        private Reservation CreateValidReservation()
        {
            var result = Reservation.Create(new MeetingRoom(), new MeetingRequest());
            return result.Value;
        }

        [Fact]
        public void Process_AllOk_ReservationIsSuccess()
        {
            var service = _serviceBuilder.Build();
            var reservation = CreateValidReservation();

            var result = service.Process(reservation);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Process_OverlappingAppointment_ShouldFail()
        {
            var service = _serviceBuilder.WithNoRoomsAvailable().Build();
            var reservation = CreateValidReservation();

            var result = service.Process(reservation);

            Assert.True(result.IsFailure);
            Assert.Equal("Meeting Overlap", result.Error);
        }
    }
}
