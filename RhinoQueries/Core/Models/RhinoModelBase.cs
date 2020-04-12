using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Collections;

namespace RhinoQueries.Core.Models
{
    public abstract class RhinoModelBase
    {
        public readonly string Name;

        // TODO: NameValueCollection can be converted to IQueryable!
        public NameValueCollection Data;

        protected RhinoModelBase(string name, NameValueCollection data)
        {
            Name = name ?? "Unnamed";
            Data = data;
        }
    }
}
