using System;

namespace Juntas.Core
{
    public class Reservation
    {
        public MeetingSchedule Schedule { get; }

        private Reservation(MeetingSchedule schedule)
        {
            Schedule = schedule;
        }

        public static Result<Reservation> Create(MeetingRoom meetingRoom, MeetingRequest meetingRequest)
        {
            return Result.Ok(new Reservation(meetingRequest.Schedule));
        }
    }
}