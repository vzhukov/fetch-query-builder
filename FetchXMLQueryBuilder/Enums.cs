using System;
using System.Collections.Generic;
using System.Text;

namespace FetchXMLQueryBuilder
{
    public enum AggregateType
    {

        Count,
        CountColumn,
        Sum,
        Avg,
        Min,
        Max
    }

    public enum BuildVersion
    {

        Item1504021,
        Item1003017
    }

    public enum DateGroupingType
    {
        Day,
        Week,
        Month,
        Quarter,
        Year,
        FiscalPeriod,
        FiscalYear
    }

    public enum FetchTypeMapping
    {

        Internal,
        Logical
    }

    public enum FilterType
    {
        And,
        Or,
    }

    public enum ItemsChoiceType
    {
        Ascend,
        Column,
        Descend,
        Filter
    }

    public enum LinkType
    {
        Outer = 0,
        Inner = 1
    }

    public enum OutputFormat
    {
        XmlAdo,
        XmlAuto,
        XmlElements,
        XmlRaw,
        XmlPlatform
    }

    public enum RowAggregateType
    {
        CountChildren
    }
}
