using System;
using Juntas.Core;
using Xunit;

namespace Juntas.UnitTests
{
    public class ReservationTest
    {
        private MeetingRequest CreateValidMeetingRequest()
        {
            var meetingRequest = new MeetingRequest();
            var schedule = new MeetingSchedule();
            schedule.Start = DateTime.Now;
            schedule.End = DateTime.Now.AddHours(1);
            meetingRequest.Schedule = schedule;
            return meetingRequest;
        }

        [Fact]
        public void Create_AllOk_ShouldSucceed()
        {
            var meetingRoom = new MeetingRoom();
            var meetingRequest = CreateValidMeetingRequest();

            var result = Reservation.Create(meetingRoom, meetingRequest);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Create_AllOk_ShouldSetValidScheduleDates()
        {
            var meetingRoom = new MeetingRoom();
            var meetingRequest = CreateValidMeetingRequest();

            var result = Reservation.Create(meetingRoom, meetingRequest);

            Assert.Equal(result.Value.Schedule.Start, meetingRequest.Schedule.Start);
            Assert.Equal(result.Value.Schedule.End, meetingRequest.Schedule.End);
        }
    }
}