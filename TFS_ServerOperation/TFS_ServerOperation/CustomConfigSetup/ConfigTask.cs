using System.Configuration;

namespace TFS_ServerOperation.CustomConfigSetup
{
    public class ConfigTask : ConfigurationElement
    {
        [ConfigurationProperty("Title", IsRequired = true, IsKey = true)]
        public string Title { get { return (string)base["Title"]; } }

        [ConfigurationProperty("AssingTo", IsRequired = true, IsKey = true)]
        public string AssingTo { get { return (string)base["AssingTo"]; } }

        [ConfigurationProperty("Effort", IsRequired = true, IsKey = true)]
        public string Effort { get { return (string)base["Effort"]; } }
    }
}
