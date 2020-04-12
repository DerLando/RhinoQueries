using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.DocObjects;
using Rhino.UI.Controls.DataSource;
using RhinoQueries.Core.Models;
using EventArgs = System.EventArgs;

namespace RhinoQueries.Core.Tables
{
    public class ObjectModelTable : TableBase, IEnumerable<RhinoObjectModel>
    {
        private List<RhinoObjectModel> _objects = new List<RhinoObjectModel>();

        public ObjectModelTable(RhinoDoc doc)
        {
            _objects = ExtractObjectModels(doc);

            RhinoDoc.ModifyObjectAttributes += OnModifyObjectAttributes;
        }

        private void OnModifyObjectAttributes(object sender, RhinoModifyObjectAttributesEventArgs e)
        {
            _objects = ExtractObjectModels(e.Document);
            OnCollectionChanged(new EventArgs());
        }

        private List<RhinoObjectModel> ExtractObjectModels(RhinoDoc doc)
        {
            var objects = new List<RhinoObjectModel>();

            foreach (var docObject in doc.Objects.FindByUserString("*", "*", false))
            {
                objects.Add(new RhinoObjectModel(docObject.Name, docObject.Attributes.GetUserStrings(), docObject.Id));
            }

            return objects;
        }

        public IEnumerator<RhinoObjectModel> GetEnumerator()
        {
            return _objects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
