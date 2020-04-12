using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
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

        #region Query helpers

        public bool HasValue(string key)
        {
            return Data.AllKeys.Contains(key);
        }

        public bool ContainsValue(string key, string value)
        {
            return HasValue(key) && Data[key].Contains(value);
        }

        private static bool ToNumbers(string key, string value, out double dKey, out double dValue)
        {
            var isKeyConverted = double.TryParse(key, out dKey);
            var isValueConverted = double.TryParse(value, out dValue);

            return isValueConverted & isValueConverted;
        }

        public bool SmallerThenValue(string key, string value)
        {
            if (!HasValue(key)) return false;
            if (!ToNumbers(key, value, out var dKey, out var dValue)) return false;

            return dKey < dValue;
        }

        public bool EqualsValue(string key, string value)
        {
            if (!HasValue(key)) return false;
            if (!ToNumbers(key, value, out var dKey, out var dValue)) return false;

            return Math.Abs(dKey - dValue) < 0.01;
        }

        public bool GreaterThenValue(string key, string value)
        {
            if (!HasValue(key)) return false;
            if (!ToNumbers(key, value, out var dKey, out var dValue)) return false;

            return dKey > dValue;
        }

        #endregion
    }
}
