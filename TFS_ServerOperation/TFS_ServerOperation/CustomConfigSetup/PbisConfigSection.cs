using System.Configuration;

namespace TFS_ServerOperation.CustomConfigSetup
{
    public class PbisConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("PBIS", IsDefaultCollection = true, IsKey = false, IsRequired = true)]
        public PBIS Members
        {
            get
            {
                return base["PBIS"] as PBIS;
            }

            set
            {
                base["PBIS"] = value;
            }
        }
    }
}
