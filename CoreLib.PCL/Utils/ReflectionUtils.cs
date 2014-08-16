using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;

namespace CoreLib
{
	public class ReflectionUtils
	{
		public static string GetPropertyName(Expression<Func<object>> exp)
		{
			MemberExpression body = exp.Body as MemberExpression;

			if (body == null) 
			{
				UnaryExpression ubody = (UnaryExpression)exp.Body;
				body = ubody.Operand as MemberExpression;
			}

			return body.Member.Name;
		}
	}
}
