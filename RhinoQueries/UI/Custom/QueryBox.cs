using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eto.Drawing;
using Eto.Forms;
using RhinoQueries.UI.Models;

namespace RhinoQueries.UI.Custom
{
    public class QueryBox : GroupBox
    {
        public QueryGroup Model;
        public bool IsAnd;
        public List<QueryRow> Rows = new List<QueryRow>();

        private Button _btn_Create = new Button{Text = "Create"};
        private Button _btn_Delete = new Button{Text = "Delete"};

        public QueryBox(QueryGroup group)
        {
            Text = "Query";

            Model = group;
            IsAnd = Model.IsAnd;

            Model.CollectionChanged += OnGroupMembersChanged;
            _btn_Create.Click += OnCreateClicked;
            _btn_Delete.Click += OnDeleteClicked;

            foreach (var model in Model)
            {
                Rows.Add(new QueryRow(model));
            }

            Content = GenerateLayout();
        }

        private DynamicLayout GenerateLayout()
        {
            // layout
            var layout = new DynamicLayout(Rows);
            layout.Padding = 10;
            layout.Spacing = new Size(5, 5);

            var row = layout.BeginHorizontal();
            row.Add(new[] { _btn_Create, _btn_Delete });
            layout.EndHorizontal();
            layout.Add(null);

            return layout;
        }

        private void OnGroupMembersChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Rows = (from model in Model select new QueryRow(model)).ToList();
            Content = GenerateLayout();

            Invalidate(true);
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            Model.AddQuery();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            Model.RemoveQuery(Model.Last());
        }


    }
}
