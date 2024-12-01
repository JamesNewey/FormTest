using System.Linq.Expressions;
using System.Reflection;

namespace FormsTest.Services
{
    public interface IFormFieldSelector<TModel>
    {
        List<PropertyInfo> PropertyInfos { get; set; }

        public FormFieldBuilder<TModel> DoMapping<TProp>(Expression<Func<TModel, TProp>> property);
    }

    public class FormFieldSelector<TModel> : IFormFieldSelector<TModel>
    {
        public List<PropertyInfo> PropertyInfos { get; set; } = new List<PropertyInfo>();

        public FormFieldBuilder<TModel> DoMapping<TProp>(Expression<Func<TModel, TProp>> property)
        {
            var formFieldBuilder = new FormFieldBuilder<TModel>();

            //var propertyInfo = AnnotationUtilities.GetPropertyFromExpression(property);
            var propertyInfo = AnnotationUtilities.GetPropertyInfo(property);

            PropertyInfos.Add(propertyInfo);

            return formFieldBuilder;
        }
    }
}
