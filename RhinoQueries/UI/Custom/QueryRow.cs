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
        private EnumDropDown<Models.ValueRelation> _edd_Relation = new EnumDropDown<ValueRelation>();
        private TextBox _tb_Comparison = new TextBox();

        public QueryRow(QueryModel model)
        {
            Model = model;

            // bindings
            _tb_Value.TextBinding.Bind(Model, m => m.Value);
            _tb_Comparison.Bind(c => c.Enabled, Model, m => m.IsComparable);
            _tb_Comparison.TextBinding.Bind(Model, m => m.Comparison);
            _edd_Relation.SelectedValueBinding.Bind(Model, m => m.ValueRelation);

            // inital settings
            _tb_Value.PlaceholderText = "Key";
            _tb_Comparison.PlaceholderText = "Value to compare against";

            // layout
            Add(new Control[] { _tb_Value, _edd_Relation, _tb_Comparison });
        }
    }
}
