using System;
using System.Configuration;

namespace TFS_ServerOperation.CustomConfigSetup
{
    public class PBIS : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PBI();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PBI)element).Title;
        }

        protected override string ElementName
        {
            get
            {
                return "PBI";
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return !String.IsNullOrEmpty(elementName) && elementName == "PBI";
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        public PBI this[int index]
        {
            get
            {
                return base.BaseGet(index) as PBI;
            }
        }

        public new PBI this[string key]
        {
            get
            {
                return base.BaseGet(key) as PBI;
            }
        }
    }
}
