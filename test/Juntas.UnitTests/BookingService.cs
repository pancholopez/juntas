using System;
using Juntas.Core;
using Moq;
using Xunit;

namespace Juntas.UnitTests
{
    public class BookingService
    {
        [Fact]
        public void Process_AllOk_ReservationIsSuccess()
        {
            var serviceMock = new Mock<IBookingService>();
            serviceMock.Setup(x => x.Process(It.IsAny<Reservation>())).Returns(Result.Ok);
            var service = serviceMock.Object;
            var reservation = new Reservation();

            var result = service.Process(reservation);

            Assert.True(result.IsSuccess);
        }
    }
}
