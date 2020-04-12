using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.DocObjects;

namespace RhinoQueries.Core.Extensions
{
    public static class UserDataExtensions
    {
        public static NameValueCollection ExtractUserStrings(this RhinoDoc doc)
        {
            var collection = new NameValueCollection();

            // Rhino Objects
            foreach (var rhinoObject in doc.Objects.FindByUserString("*", "*", false))
            {
                collection.Add(rhinoObject.Attributes.GetUserStrings());
            }

            // Layouts
            foreach (var rhinoPageView in doc.Views.GetPageViews())
            {
                collection.Add(rhinoPageView.ActiveViewport.GetUserStrings());
            }

            return collection;
        }

        public static string[] ExtractUserKeys(this RhinoDoc doc)
        {
            return doc.ExtractUserStrings().AllKeys;
        }
    }
}
