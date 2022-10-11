namespace Api_dotnet.Services
{
    public class TimeService : ITimeService
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToLocalTime().ToString();
        }
    }

    public interface ITimeService
    {
        string GetDateTime();
    }
}
