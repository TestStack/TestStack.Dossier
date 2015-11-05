using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestStack.Dossier
{
    internal class PathExpressionVisitor : ExpressionVisitor
    {
        internal readonly List<string> Path = new List<string>();

        protected override Expression VisitMember(MemberExpression node)
        {
            Path.Add(node.Member.Name);
            return base.VisitMember(node);
        }
    }

}
