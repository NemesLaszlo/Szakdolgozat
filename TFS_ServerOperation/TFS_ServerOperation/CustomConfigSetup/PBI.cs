using System.Configuration;

namespace TFS_ServerOperation.CustomConfigSetup
{
    public class PBI : ConfigurationElement
    {
        [ConfigurationProperty("Title", IsKey = true)]
        public string Title { get { return (string)this["Title"]; } }

        [ConfigurationProperty("ParentID", IsKey = true)]
        public string ParentID { get { return (string)this["ParentID"]; } }

        [ConfigurationProperty("AssignedTo", IsKey = true)]
        public string AssignedTo { get { return (string)this["AssignedTo"]; } }

        [ConfigurationProperty("Tasks", IsRequired = true, IsDefaultCollection = true)]
        public Tasks Tasks
        {
            get { return base["Tasks"] as Tasks; }
        }
    }

    [ConfigurationCollection(typeof(ConfigTask))]
    public class Tasks : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigTask();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigTask)element).Title;
        }

        protected object GetElementAssingedTo(ConfigurationElement element)
        {
            return ((ConfigTask)element).AssingTo;
        }

        protected object GetElementEffort(ConfigurationElement element)
        {
            return ((ConfigTask)element).Effort;
        }
    }
}
