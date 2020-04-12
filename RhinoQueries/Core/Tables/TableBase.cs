using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoQueries.Core.Tables
{
    public abstract class TableBase
    {
        public event EventHandler CollectionChanged;

        protected virtual void OnCollectionChanged(EventArgs e)
        {
            var handler = CollectionChanged;
            handler?.Invoke(this, e);
        }
    }
}
