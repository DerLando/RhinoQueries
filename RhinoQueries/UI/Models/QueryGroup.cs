using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoQueries.UI.Models
{
    public class QueryGroup : ObservableCollection<QueryModel>
    {
        public bool IsAnd;
        public bool IsOr => !IsAnd;

        public QueryGroup()
        {
            IsAnd = false;
            Add(new QueryModel());
        }

        public int AddQuery()
        {
            Add(new QueryModel());
            return Count - 1;
        }

        public void RemoveQuery(QueryModel model)
        {
            Remove(model);
        }
    }
}
