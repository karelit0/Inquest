using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ExpresionFilter.ExpressionBuilder
{
    public class SortExpressionConverter<T>
    {
        public Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> GetAscendingExpression()
        {
            return (c, f) => c.OrderBy(f);
        }

        public Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> GetDescendingExpression()
        {
            return (c, f) => c.OrderByDescending(f);
        }


        public Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> Convert(bool ascending)
        {
            return ascending ? GetAscendingExpression() : GetDescendingExpression();
        }


    }
}
