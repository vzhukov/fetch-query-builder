using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class Attribute {
        public string Name { get; set; }

        public BuildVersion? Build { get; set; }

        public string AddedBy { get; set; }

        public string Alias { get; set; }

        public AggregateType? Aggregate { get; set; }

        public bool? GroupBy { get; set; }

        public DateGroupingType? DateGrouping { get; set; }

        public bool? UserTimeZone { get; set; }

        public bool? Distinct { get; set; }

        public XElement Xml()
        {
            var xml = new XElement("attribute",
                new XAttribute("name", Name));
            if (!string.IsNullOrEmpty(Alias))
            {
                xml.Add(new XAttribute("alias", Alias));
            }
            if (Build != null)
            {
                xml.Add(new XAttribute("build", Build == BuildVersion.Item1003017 ? "1.003017" : "1.504021"));
            }
            if (!string.IsNullOrEmpty(AddedBy))
            {
                xml.Add(new XAttribute("addedby", AddedBy));
            }
            if (Aggregate!=null)
            {
                xml.Add(new XAttribute("aggregate", Aggregate.Value.ToString("G").ToLower()));
            }
            if (GroupBy.HasValue)
            {
                xml.Add(new XAttribute("groupby", GroupBy.Value ? "true" : "false"));
            }
            if (DateGrouping.HasValue)
            {
                xml.Add(new XAttribute("dategrouping", DateGrouping.Value.ToString("G").ToLower()));
            }
            if (UserTimeZone.HasValue)
            {
                xml.Add(new XAttribute("usertimezone", UserTimeZone.Value ? "true" : "false"));
            }
            if (Distinct.HasValue)
            {
                xml.Add(new XAttribute("distinct", Distinct.Value ? "true" : "false"));
            }
            return xml;
        }
    }
}