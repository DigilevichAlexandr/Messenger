using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Data
{
    public class PageOptions
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        ///// <summary>
        ///// Column name, value
        ///// </summary>
        //public IDictionary<string, string> Filter { get; set; }
        //public SortOrder SortOrder { get; set; }
    }

    public class SortOrder
    {
        public string Field { get; set; }
        public Order Order { get; set; }
    }

    public enum Order
    {
        Desc, Asc
    }
}
