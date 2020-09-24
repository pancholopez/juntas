namespace Juntas.Core
{
    public interface IRoomLookupService
    {
        bool IsAvailable(string meetingRoomId, MeetingSchedule schedule);
    }
}