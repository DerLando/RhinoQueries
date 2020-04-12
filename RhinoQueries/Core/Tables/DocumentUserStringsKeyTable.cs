using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.DocObjects;
using Rhino.UI.Controls.DataSource;
using RhinoQueries.Core.Extensions;
using EventArgs = System.EventArgs;

namespace RhinoQueries.Core.Tables
{
    public class DocumentUserStringsKeyTable : TableBase, IEnumerable<string>
    {
        private string[] _keys;

        public DocumentUserStringsKeyTable(RhinoDoc doc)
        {
            _keys = doc.ExtractUserKeys();

            RhinoDoc.ModifyObjectAttributes += OnModifyObjectAttributes;
        }

        private void OnModifyObjectAttributes(object sender, RhinoModifyObjectAttributesEventArgs e)
        {
            _keys = e.Document.ExtractUserKeys();
            OnCollectionChanged(new EventArgs());
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _keys.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
