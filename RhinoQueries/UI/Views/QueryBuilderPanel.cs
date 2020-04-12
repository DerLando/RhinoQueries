using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Eto.Drawing;
using Eto.Forms;
using Rhino.UI;
using RhinoQueries.UI.Custom;
using RhinoQueries.UI.Models;

namespace RhinoQueries.UI.Views
{
    [Guid("168A58A4-8F42-4E1E-980C-345B9824805F")]
    public class QueryBuilderPanel : Panel, IPanel
    {
        // fields
        private readonly uint _document_sn;
        private QueryTree _qTree = new QueryTree();

        // Auto-initialized properties
        public static Guid PanelId => typeof(QueryBuilderPanel).GUID;

        public QueryBuilderPanel(uint documentSerialNumber)
        {
            _document_sn = documentSerialNumber;


            Content = GenerateContent();

            _qTree.CollectionChanged += OnQueryTreeChanged;
        }

        private DynamicLayout GenerateContent()
        {
            var layout = new DynamicLayout();
            layout.Padding = 10;
            layout.Spacing = new Size(5, 5);

            foreach (var group in _qTree)
            {
                layout.Add(new QueryBox(group));
            }

            layout.Add(null);

            return layout;
        }

        private void OnQueryTreeChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Content = GenerateContent();
            Invalidate(true);
        }

        #region IPanel methods

        public void PanelShown(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is made visible, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine($"Panel shown for document {documentSerialNumber}, this serial number {_document_sn} should be the same");
        }

        public void PanelHidden(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is hidden, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine($"Panel hidden for document {documentSerialNumber}, this serial number {_document_sn} should be the same");
        }

        public void PanelClosing(uint documentSerialNumber, bool onCloseDocument)
        {
            // Called when the document or panel container is closed/destroyed
            Rhino.RhinoApp.WriteLine($"Panel closing for document {documentSerialNumber}, this serial number {_document_sn} should be the same");
        }

        #endregion IPanel methods
    }
}
