using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoQueries.UI.Models
{
    public class QueryModel
    {
        public string Value { get; set; } = "";
        public ValueRelation ValueRelation { get; set; } = ValueRelation.HasValue;
        public string Comparison { get; set; }= "";

        public bool IsComparable
        {
            get { return ValueRelation != ValueRelation.HasValue; }
        }

    }

    public enum ValueRelation
    {
        Contains,
        Larger,
        Smaller,
        Equals,
        HasValue,
    }
}
