using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoQueries.UI.Models
{
    public class QueryModel
    {
        public string Value = "";
        public ValueRelation ValueRelation = ValueRelation.HasValue;
        public string Comparison = "";

        public bool IsComparable => ValueRelation != ValueRelation.HasValue;

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
