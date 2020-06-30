using System.Security.Cryptography;
using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class Order
    {
        public Order(){}

        public Order(string attribute, bool desc = false)
        {
            Attribute = attribute;
            Descending = desc;
        }

        public string Attribute { get; set; }

        public string Alias { get; set; }

        public bool Descending { get; set; } = false;

        public XElement Xml()
        {
            var xml = new XElement("order",
                new XAttribute("attribute", Attribute),
                new XAttribute("descending", Descending ? "true" : "false"));
            if (!string.IsNullOrEmpty(Alias))
            {
                xml.Add(new XAttribute("alias", Alias));
            }

            return xml;
        }
    }
}