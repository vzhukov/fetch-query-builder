using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class Entity
    {
        public Entity(){}

        public Entity(string entityName)
        {
            Name = entityName;
        }

        public bool? AllAttributes { get; set; }

        public IEnumerable<Attribute> Attributes { get; set; }
    
        public IEnumerable<LinkEntity> LinkEntities { get; set; }
        
        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<Filter> Filters { get; set; }

        public string Name { get; set; }

        public bool? EnablePreFiltering { get; set; }

        public string PreFilterParameterName { get; set; }

        public XElement Xml()
        {
            var xml = new XElement("entity",
                new XAttribute("name", Name));
            if (Orders?.Count() > 0)
            {
                foreach (var order in Orders)
                {
                    xml.Add(order.Xml());
                }
            }

            if (AllAttributes == true)
            {
                xml.Add(new XElement("all-attributes"));
            }
            else
            {
                if (Attributes?.Count() > 0)
                {
                    foreach (var attribute in Attributes)
                    {
                        xml.Add(attribute.Xml());
                    }
                }
            }
            
            if (Filters?.Count() > 0)
            {
                foreach (var filter in Filters)
                {
                    xml.Add(filter.Xml());
                }
            }
            if (LinkEntities?.Count() > 0)
            {
                foreach (var entity in LinkEntities)
                {
                    xml.Add(entity.Xml());
                }
            }

            if (EnablePreFiltering.HasValue)
            {
                xml.Add(new XAttribute("enableprefiltering", EnablePreFiltering.Value ? "true" : "false"));
                if (!string.IsNullOrEmpty(PreFilterParameterName))
                {
                    xml.Add(new XAttribute("prefilterparametername", PreFilterParameterName));
                }
            }

            return xml;
        }
    }
}