using System.Linq.Expressions;
using System.Reflection;
using FormsTest.Models.Form;

namespace FormsTest.Services
{
    public interface IFormFieldSelector<TModel>
    {
        List<PropertyInfo> PropertyInfos { get; set; }

        public FormFieldBuilder<TModel, TProp> AddField<TProp>(Expression<Func<TModel, TProp>> property);
    }

    public class FormFieldSelector<TModel> : IFormFieldSelector<TModel>
    {
        public List<PropertyInfo> PropertyInfos { get; set; } = new List<PropertyInfo>();

        public FormFieldBuilder<TModel, TProp> AddField<TProp>(Expression<Func<TModel, TProp>> property)
        {
            var formFieldBuilder = new FormFieldBuilder<TModel, TProp>();

            var typedFormFieldSource = new TypedFormFieldSource<TProp, Expression<Func<TModel, TProp>>>();
            typedFormFieldSource.Expression = property;




            //var propertyInfo = AnnotationUtilities.GetPropertyFromExpression(property);
            var propertyInfo = AnnotationUtilities.GetPropertyInfo(property);

            typedFormFieldSource.PropertyInfo = propertyInfo;

            PropertyInfos.Add(propertyInfo);

            return formFieldBuilder;
        }
    }
}
