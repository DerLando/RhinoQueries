using System;
using System.Collections.Generic;
using System.Linq;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.UI;
using RhinoQueries.Core.Extensions;
using RhinoQueries.Core.Parsing;
using RhinoQueries.Core.Tables;
using RhinoQueries.UI.Views;

namespace RhinoQueries
{
    public class rqTestCommand : Command
    {
        public rqTestCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static rqTestCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "rqTestCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoApp.WriteLine("The {0} command is under construction.", EnglishName);

            var table = new ObjectModelTable(doc);

            var keys = doc.ExtractUserKeys();

            var panel = Panels.GetPanel<QueryBuilderPanel>(doc);

            var queried =
                from obj in table
                where QueryParser.IsValid(obj, panel._qTree[0])
                select obj;

            doc.Objects.Select(from q in queried select q.Id);

            doc.Views.Redraw();

            return Result.Success;
        }
    }
}
