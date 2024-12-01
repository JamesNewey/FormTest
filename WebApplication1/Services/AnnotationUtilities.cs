using System.Linq.Expressions;
using System.Reflection;

namespace FormsTest.Services
{
    public static class AnnotationUtilities
    {
        public static T GetAttributeFrom<T>(object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).FirstOrDefault();
        }

        /// <summary>
        ///     Gets the corresponding <see cref="PropertyInfo" /> from an <see cref="Expression" />.
        /// </summary>
        /// <param name="property">The expression that selects the property to get info on.</param>
        /// <returns>The property info collected from the expression.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="property" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The expression doesn't indicate a valid property."</exception>
        public static PropertyInfo GetPropertyInfo<T, P>(Expression<Func<T, P>> property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Body is UnaryExpression unaryExp)
            {
                if (unaryExp.Operand is MemberExpression memberExp)
                {
                    return (PropertyInfo)memberExp.Member;
                }
            }
            else if (property.Body is MemberExpression memberExp)
            {
                return (PropertyInfo)memberExp.Member;
            }

            throw new ArgumentException($"The expression doesn't indicate a valid property. [ {property} ]");
        }

        public static PropertyInfo GetPropertyFromExpression<T>(Expression<Func<T, object>> GetPropertyLambda)
        {
            MemberExpression Exp = null;

            //this line is necessary, because sometimes the expression comes in as Convert(originalexpression)
            if (GetPropertyLambda.Body is UnaryExpression)
            {
                var UnExp = (UnaryExpression)GetPropertyLambda.Body;
                if (UnExp.Operand is MemberExpression)
                {
                    Exp = (MemberExpression)UnExp.Operand;
                }
                else
                    throw new ArgumentException();
            }
            else if (GetPropertyLambda.Body is MemberExpression)
            {
                Exp = (MemberExpression)GetPropertyLambda.Body;
            }
            else
            {
                throw new ArgumentException();
            }

            return (PropertyInfo)Exp.Member;
        }
    }
}
