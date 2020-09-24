using System;

namespace Juntas.Core
{
    public class Reservation
    {
        public string MeetingRoomId { get; set; }
        public MeetingSchedule Schedule { get; }

        private Reservation(string meetingRoomId, MeetingSchedule schedule)
        {
            MeetingRoomId = meetingRoomId;
            Schedule = schedule;
        }

        public static Result<Reservation> Create(MeetingRoom meetingRoom, MeetingRequest meetingRequest)
        {
            return Result.Ok(new Reservation(meetingRoom.Id, meetingRequest.Schedule));
        }
    }
}