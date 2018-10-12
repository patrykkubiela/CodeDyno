using System;
using System.Linq.Expressions;

namespace CodeDyno.Common
{
    public static class CommonExtensions
    {
        public static string GetParameterName<T>(Expression<Func<T>> parameter)
        {
            var expressionBody = (MemberExpression)parameter.Body;
            return expressionBody.Member.Name;
        }
    }
}
