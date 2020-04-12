using System;
using Rhino;
using Rhino.Commands;
using Rhino.UI;
using RhinoQueries.UI.Views;

namespace RhinoQueries.Commands
{
    public class rqQueryBuilderPanel : Command
    {
        static rqQueryBuilderPanel _instance;
        public rqQueryBuilderPanel()
        {
            // register UserStringManagerPanel
            Panels.RegisterPanel(PlugIn, typeof(QueryBuilderPanel), "User strings", null);

            _instance = this;
        }

        ///<summary>The only instance of the rqQueryBuilderPanel command.</summary>
        public static rqQueryBuilderPanel Instance
        {
            get { return _instance; }
        }

        public override string EnglishName
        {
            get { return "rqQueryBuilderPanel"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var panelId = QueryBuilderPanel.PanelId;
            var visible = Panels.IsPanelVisible(panelId);

            var prompt = (visible)
                ? "Query builder panel is visible"
                : "Query builder panel is hidden";

            RhinoApp.WriteLine(prompt);

            // toggle visible
            if (!visible)
            {
                Panels.OpenPanel(panelId);
            }
            else Panels.ClosePanel(panelId);
            return Result.Success;
        }
    }
}