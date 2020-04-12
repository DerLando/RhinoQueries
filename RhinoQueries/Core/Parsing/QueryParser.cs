using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RhinoQueries.Core.Models;
using RhinoQueries.UI.Models;

namespace RhinoQueries.Core.Parsing
{
    public static class QueryParser
    {
        // TODO: Try out expression trees for queries instead
        public static bool IsValid(RhinoModelBase rModel, QueryModel qModel)
        {
            var result = false;
            switch (qModel.ValueRelation)
            {
                case ValueRelation.Contains:
                    result = rModel.ContainsValue(qModel.Value, qModel.Comparison);
                    break;
                case ValueRelation.Larger:
                    result = rModel.GreaterThenValue(qModel.Value, qModel.Comparison);
                    break;
                case ValueRelation.Smaller:
                    result = rModel.SmallerThenValue(qModel.Value, qModel.Comparison);
                    break;
                case ValueRelation.Equals:
                    result = rModel.EqualsValue(qModel.Value, qModel.Comparison);
                    break;
                case ValueRelation.HasValue:
                    result = rModel.HasValue(qModel.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        public static bool IsValid(RhinoModelBase rModel, QueryGroup qGroup)
        {
            var result = false;
            if (qGroup.IsAnd)
            {
                foreach (var qModel in qGroup)
                {
                    result &= IsValid(rModel, qModel);
                }
            }
            else
            {
                foreach (var qModel in qGroup)
                {
                    result |= IsValid(rModel, qModel);
                }
            }

            return result;
        }
    }
}
