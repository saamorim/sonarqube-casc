namespace SonarConfiguratorAsCode
{
    public class CascConfiguration
    {
        public CascAdminConfig Admin { get; set; }
    }

    public class CascAdminConfig
    {
        public CascSystemConfig System { get; set; }
        public CascSystemAcl Acl { get; set; }
    }

    public class CascSystemConfig
    {
        public CascLogLevel Loglevel { get; set; }
    }

    public class CascSystemAcl
    {
        public CascGroup[] Groups { get; set; }
    }

    public class CascGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CascGroupPermission[] Permissions { get; set; }
    }

    public enum CascGroupPermission
    {
        admin,
        profileadmin,
        gateadmin,
        scan,
        provisioning
    }

    public enum CascLogLevel
    {
        TRACE,
        DEBUG,
        INFO
    }
}