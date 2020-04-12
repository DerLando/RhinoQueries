using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Eto.Drawing;
using Eto.Forms;
using Rhino;
using Rhino.UI;
using RhinoQueries.Core.Tables;

namespace RhinoQueries.UI.Views
{
    [Guid("9BB7ED64-D839-4D43-AD30-0774467A5995")]
    public class UserStringManagerPanel : Panel, IPanel
    {
        // fields
        private readonly uint _document_sn;
        public DocumentUserStringsKeyTable _key_table;

        // controls
        private ListBox _lb_keys = new ListBox();

        // Auto-initialized properties
        public static Guid PanelId => typeof(UserStringManagerPanel).GUID;


        public UserStringManagerPanel(uint documentSerialNumber)
        {
            _document_sn = documentSerialNumber;
            _key_table = new DocumentUserStringsKeyTable(RhinoDoc.FromRuntimeSerialNumber(documentSerialNumber));

            // set up event handlers
            _key_table.CollectionChanged += OnKeyTableChanged;

            // set up list box
            _lb_keys.DataStore = _key_table;

            // write layout
            var layout = new DynamicLayout();
            layout.Padding = 10;
            layout.Spacing = new Size(5, 5);

            layout.Add(_lb_keys);
            layout.Add(null);

            Content = layout;
        }

        private void OnKeyTableChanged(object sender, EventArgs e)
        {
            _lb_keys.DataStore = _key_table;
            _lb_keys.Invalidate();
        }


        #region IPanel methods

        public void PanelShown(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is made visible, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine(
                $"Panel shown for document {documentSerialNumber}, this serial number {_document_sn} should be the same");
        }

        public void PanelHidden(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is hidden, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine(
                $"Panel hidden for document {documentSerialNumber}, this serial number {_document_sn} should be the same");
        }

        public void PanelClosing(uint documentSerialNumber, bool onCloseDocument)
        {
            // Called when the document or panel container is closed/destroyed
            Rhino.RhinoApp.WriteLine(
                $"Panel closing for document {documentSerialNumber}, this serial number {_document_sn} should be the same");
        }

        #endregion IPanel methods

    }
}
