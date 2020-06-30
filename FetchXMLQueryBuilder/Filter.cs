using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class Filter {

        public Filter()
        {

        }

        public Filter(FilterType type = FilterType.And)
        {
            Type = type;
        }

        public IEnumerable<Condition> Conditions { get; set; }

        public IEnumerable<Filter> Filters { get; set; }

        public FilterType Type { get; set; } = FilterType.And;

        public bool? IsQuickFindFields { get; set; }

        public XElement Xml()
        {
            var xml = new XElement("filter",
                new XAttribute("type", Type == FilterType.And ? "and" : "or"));
            if (IsQuickFindFields.HasValue)
            {
                xml.Add(new XAttribute("isquickfindfields", IsQuickFindFields.Value ? "true" : "false"));
            }
            if (Conditions?.Count() > 0)
            {
                foreach (var condition in Conditions)
                {
                    xml.Add(condition.Xml());
                }
            }
            if (Filters?.Count() > 0)
            {
                foreach (var filter in Filters)
                {
                    xml.Add(filter.Xml());
                }
            }

            return xml;
        }
    }
}