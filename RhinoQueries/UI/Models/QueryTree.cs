using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoQueries.UI.Models
{
    public class QueryTree : ObservableCollection<QueryGroup>
    {
        public QueryTree()
        {
            Add(new QueryGroup());
        }
    }
}
