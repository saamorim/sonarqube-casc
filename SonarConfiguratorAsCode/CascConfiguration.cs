namespace SonarConfiguratorAsCode
{
    public class CascConfiguration
    {
        public CascAdminConfig Admin { get; set; }
    }

    public class CascAdminConfig
    {
        public CascSystemConfig System { get; set; }
    }

    public class CascSystemConfig
    {
        public CascLogLevel Loglevel { get; set; }
    }

    public enum CascLogLevel
    {
        TRACE,
        DEBUG,
        INFO
    }
}