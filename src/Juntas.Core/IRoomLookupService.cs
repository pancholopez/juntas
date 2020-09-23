namespace Juntas.Core
{
    public interface IRoomLookupService
    {
        bool IsAvailable(MeetingSchedule schedule);
    }
}