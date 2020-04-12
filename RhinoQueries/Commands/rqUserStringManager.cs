using System;
using Rhino;
using Rhino.Commands;
using Rhino.UI;
using RhinoQueries.UI.Views;

namespace RhinoQueries.Commands
{
    public class rqUserStringManager : Command
    {
        static rqUserStringManager _instance;
        public rqUserStringManager()
        {
            // register UserStringManagerPanel
            Panels.RegisterPanel(PlugIn, typeof(UserStringManagerPanel), "User strings", null);
            _instance = this;
        }

        ///<summary>The only instance of the rqUserStringManager command.</summary>
        public static rqUserStringManager Instance
        {
            get { return _instance; }
        }

        public override string EnglishName
        {
            get { return "rqUserStringManager"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var panelId = UserStringManagerPanel.PanelId;
            var visible = Panels.IsPanelVisible(panelId);

            var prompt = (visible)
                ? "User strings panel is visible"
                : "User strings panel is hidden";

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