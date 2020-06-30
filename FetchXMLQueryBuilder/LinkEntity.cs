using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class LinkEntity
    {
        public bool? AllAttributes { get; set; }

        public IEnumerable<Attribute> Attributes { get; set; }

        public IEnumerable<LinkEntity> LinkEntities { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<Filter> Filters { get; set; }

        public string Name { get; set; }

        public string To { get; set; }

        public string From { get; set; }

        public string Alias { get; set; }

        public LinkType? LinkType { get; set; }

        public bool? Visible { get; set; }

        public bool? Intersect { get; set; }

        public bool? EnablePreFiltering { get; set; }

        public string PreFilterParameterName { get; set; }

        public XElement Xml()
        {
            var xml = new XElement("link-entity",
                new XAttribute("name", Name));

            if (!string.IsNullOrEmpty(From))
            {
                xml.Add(new XAttribute("from", From));
            }
            if (!string.IsNullOrEmpty(To))
            {
                xml.Add(new XAttribute("to", To));
            }
            if (!string.IsNullOrEmpty(To))
            {
                xml.Add(new XAttribute("to", To));
            }
            if (LinkType != null)
            {
                xml.Add(new XAttribute("link-type", LinkType.Value == FetchXMLQueryBuilder.LinkType.Inner ? "inner" : "outer"));
            }
            if (!string.IsNullOrEmpty(Alias))
            {
                xml.Add(new XAttribute("alias", Alias));
            }
            if (Visible.HasValue)
            {
                xml.Add(new XAttribute("visible", Visible.Value ? "true" : "false"));
            }
            if (Intersect.HasValue)
            {
                xml.Add(new XAttribute("intersect", Intersect.Value ? "true" : "false"));
            }
            if (EnablePreFiltering.HasValue)
            {
                xml.Add(new XAttribute("enableprefiltering", EnablePreFiltering.Value ? "true" : "false"));
                xml.Add(new XAttribute("prefilterparametername", PreFilterParameterName));
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
            if (Orders?.Count() > 0)
            {
                foreach (var order in Orders)
                {
                    xml.Add(order.Xml());
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

            return xml;
        }
    }
}