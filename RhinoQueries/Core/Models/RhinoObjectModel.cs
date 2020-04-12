using System;
using System.Collections.Specialized;

namespace RhinoQueries.Core.Models
{
    public class RhinoObjectModel : RhinoModelBase
    {
        public readonly Guid Id;

        public RhinoObjectModel(string name, NameValueCollection data, Guid id) : base(name, data)
        {
            Id = id;
        }

    }
}
