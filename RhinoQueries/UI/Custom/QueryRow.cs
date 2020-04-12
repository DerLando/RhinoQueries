using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eto.Drawing;
using Eto.Forms;
using RhinoQueries.UI.Models;

namespace RhinoQueries.UI.Custom
{
    public class QueryRow : DynamicRow
    {
        public QueryModel Model;

        private TextBox _tb_Value = new TextBox();
        private EnumDropDown<ValueRelation> _edd_Relation = new EnumDropDown<ValueRelation>();
        private TextBox _tb_Comparison = new TextBox();

        public QueryRow(QueryModel model)
        {
            Model = model;

            // bindings
            _tb_Value.TextBinding.Bind(Model, m => m.Value);
            _tb_Comparison.Bind(c => c.Enabled, Model, m => m.IsComparable, DualBindingMode.OneTime);
            _tb_Comparison.TextBinding.Bind(Model, m => m.Comparison);
            _edd_Relation.SelectedValueBinding.Bind(Model, m => m.ValueRelation);
            
            // TODO: Binding does not work so this is a hack :I
            _edd_Relation.SelectedValueBinding.DataValueChanged += OnValueRelationChanged;

            // inital settings
            _tb_Value.PlaceholderText = "Key";
            _tb_Comparison.PlaceholderText = "Value to compare against";

            // layout
            Add(new Control[] { _tb_Value, _edd_Relation, _tb_Comparison });
        }

        private void OnValueRelationChanged(object sender, EventArgs e)
        {
            _tb_Comparison.Enabled = Model.IsComparable;
        }
    }
}
