using System.Linq.Expressions;
using FormsTest.Models.Form;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FormsTest.Services
{
    public class FormBuilder<TModel>
    {
        protected Form _form;

        protected readonly TModel _model;

        public FormBuilder(TModel model)
        {
            _form = new Form();
            _model = model;
        }

        public FormBuilder<TModel> AddFromDataAnnotations()
        {
            Type modelType = typeof(TModel);

            foreach (var propertyInfo in modelType.GetProperties())
            {
                var reqAttribute = AnnotationUtilities.GetAttributeFrom<RequiredAttribute>(_model, propertyInfo.Name);
                var displayAttribute = AnnotationUtilities.GetAttributeFrom<DisplayNameAttribute>(_model, propertyInfo.Name);
                var readOnlyAttribute = AnnotationUtilities.GetAttributeFrom<ReadOnlyAttribute>(_model, propertyInfo.Name);

                bool isRequired = reqAttribute != null;
                _form.Fields.Add(new FormField
                {
                    Name = propertyInfo.Name,
                    DisplayName = displayAttribute == null ? propertyInfo.Name : displayAttribute.DisplayName,
                    Value = propertyInfo.GetValue(_model).ToString(),
                    IsMandatory = isRequired,
                    MandatoryValidationMessage = isRequired ? "This field is required" : string.Empty,
                    ReadOnly = readOnlyAttribute?.IsReadOnly ?? false
                });
            }

            return this;
        }

        public FormBuilder<TModel> AddProperty<TProp>(Expression<Func<TModel, TProp>> property)
        {
            return this;
        }

        //public FormBuilder<TModel> MapProperties(Func<IFormFieldSelector<TModel>> mapping)
        public FormBuilder<TModel> MapProperties(FormFieldDelegate mapping)
        {
            var thing = new FormFieldSelector<TModel>();

            mapping.Invoke(thing);

            return this;
        }

        public Form Build()
        {
            return _form;
        }

        public delegate void FormFieldDelegate(IFormFieldSelector<TModel> mapping);

        public FormFieldBuilder<TModel> DoMapping<TProp>(Func<TModel, TProp> property)
        {
            return new FormFieldBuilder<TModel>(_model);
        }

    }
}
