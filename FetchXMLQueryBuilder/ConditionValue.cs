using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class ConditionValue {
        public string UIName { get; set; }
        public string UIType { get; set; }
        public string Value { get; set; }

        public XElement Xml()
        {
            var xml = new XElement("value", Value);
            if (!string.IsNullOrEmpty(UIName))
            {
                xml.Add(new XAttribute("uiname", UIName));
            }
            if (!string.IsNullOrEmpty(UIType))
            {
                xml.Add(new XAttribute("uitype", UIType));
            }
            return xml;
        }
    }
}