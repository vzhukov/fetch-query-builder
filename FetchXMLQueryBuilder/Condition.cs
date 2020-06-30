using System.Collections.Generic;
using System.Xml.Linq;

namespace FetchXMLQueryBuilder
{
    public class Condition
    {
        public List<ConditionValue> Values { get; set; }

        public string Column { get; set; }

        public string Attribute { get; set; }

        public string EntityName { get; set; }

        public string Operator { get; set; }

        public string Value { get; set; }

        public AggregateType? Aggregate { get; set; }

        public RowAggregateType? RowAggregate { get; set; }

        public string Alias { get; set; }

        public string UIName { get; set; }

        public string UIType { get; set; }

        public bool? UIHidden { get; set; }

        public XElement Xml()
        {
            var xml = new XElement("condition",
                new XAttribute("operator", Operator));
            if (!string.IsNullOrEmpty(Column))
            {
                xml.Add(new XAttribute("column", Column));
            }
            if (!string.IsNullOrEmpty(Attribute))
            {
                xml.Add(new XAttribute("attribute", Attribute));
            }
            if (!string.IsNullOrEmpty(Value))
            {
                xml.Add(new XAttribute("value", Value));
            }
            if (!string.IsNullOrEmpty(EntityName))
            {
                xml.Add(new XAttribute("entityname", EntityName));
            }
            if (Aggregate.HasValue)
            {
                xml.Add(new XAttribute("aggregate", Aggregate.Value.ToString("G").ToLower()));
            }
            if (RowAggregate.HasValue)
            {
                xml.Add(new XAttribute("rowaggregate", RowAggregate.Value.ToString("G").ToLower()));
            }
            if (!string.IsNullOrEmpty(Alias))
            {
                xml.Add(new XAttribute("alias", Alias));
            }
            if (!string.IsNullOrEmpty(UIName))
            {
                xml.Add(new XAttribute("uiname", UIName));
            }
            if (!string.IsNullOrEmpty(UIType))
            {
                xml.Add(new XAttribute("uitype", UIType));
            }
            if (UIHidden.HasValue)
            {
                xml.Add(new XAttribute("uihidden", UIHidden.Value ? "true" : "false"));
            }

            if (Values?.Count > 0)
            {
                foreach (var value in Values)
                {
                    xml.Add(value.Xml());
                }
            }
            return xml;
        }
    }
}