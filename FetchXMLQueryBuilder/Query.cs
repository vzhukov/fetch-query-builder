using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class Query
    {
        public Query()
        {

        }

        public Query(int top)
        {
            Top = top;
        }

        public Query(int count, int page, string pagingCookie = null)
        {
            Count = count;
            Page = page;
            if (!string.IsNullOrEmpty(pagingCookie))
            {
                PagingCookie = pagingCookie;
            }
        }

        public Entity Entity { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public string Version { get; set; }

        public int Count { get; set; }

        public int Page { get; set; }

        public string PagingCookie { get; set; }

        public int? UTCOffset { get; set; }

        public bool? Aggregate { get; set; }

        public bool? Distinct { get; set; }

        public int Top { get; set; }

        public FetchTypeMapping? Mapping { get; set; }

        public bool MinActiveRowVersion { get; set; }

        public OutputFormat? OutputFormat { get; set; }

        public bool ReturnTotalRecordCount { get; set; } = false;

        public bool NoLock { get; set; } = false;

        public XElement Xml()
        {
            var xml = new XElement("fetch",
                new XAttribute("no-lock", NoLock ? "true" : "false"));
            xml.Add(new XAttribute("min-active-row-version", MinActiveRowVersion ? "true" : "false"));
            if (Distinct.HasValue)
            {
                xml.Add(new XAttribute("distinct", Distinct.Value ? "true" : "false"));
            }
            if (Top != 0)
            {
                xml.Add(new XAttribute("top", Top));
            }
            if (Aggregate.HasValue)
            {
                xml.Add(new XAttribute("aggregate", Aggregate.Value ? "true" : "false"));
            }
            else
            {
                if (ReturnTotalRecordCount)
                {
                    xml.Add(new XAttribute("returntotalrecordcount", "true"));
                }
                if (Count != 0)
                {
                    xml.Add(new XAttribute("count", Count));
                }
                if (Page != 0)
                {
                    xml.Add(new XAttribute("page", Page));
                }
            }
            if (Entity != null)
            {
                xml.Add(Entity.Xml());
            }
            if (Orders?.Count() > 0)
            {
                foreach (var order in Orders)
                {
                    xml.Add(order.Xml());
                }
            }

            if (!string.IsNullOrEmpty(Version))
            {
                xml.Add(new XAttribute("version", Version));
            }
            if (!string.IsNullOrEmpty(PagingCookie))
            {
                xml.Add(new XAttribute("paging-cookie", PagingCookie));
            }
            if (UTCOffset.HasValue)
            {
                xml.Add(new XAttribute("utc-offset", UTCOffset.Value));
            }
            if (Mapping.HasValue)
            {
                xml.Add(new XAttribute("mapping", Mapping.Value.ToString("G").ToLower()));
            }
            if (OutputFormat.HasValue)
            {
                xml.Add(new XAttribute("output-format", OutputFormat.Value.ToString("G").ToLower().Replace("xml", "xml-")));
            }
            return xml;
        }

        public override string ToString()
        {
            var xml = Xml();
            return xml.ToString();
        }
    }
}