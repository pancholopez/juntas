namespace Juntas.Core
{
    public class MeetingRequest
    {
        public Employee RequestedBy{ get; set; }
        public MeetingSchedule Schedule { get; set; }
        public int NumberOfAttendees { get; set; }
    }
}