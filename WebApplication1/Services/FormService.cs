using FormsTest.Models.Form;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FormsTest.Services
{
    public class FormService : IFormService
    {
        public Form GetForm(object obj)
        {
            var form = new Form();

            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                var reqAttribute = GetAttributeFrom<RequiredAttribute>(obj, propertyInfo.Name);
                var displayAttribute = GetAttributeFrom<DisplayNameAttribute>(obj, propertyInfo.Name);
                var readOnlyAttribute = GetAttributeFrom<ReadOnlyAttribute>(obj, propertyInfo.Name);
                
                bool isRequired = reqAttribute != null;
                form.Fields.Add(new FormField
                {
                    Name = propertyInfo.Name,
                    DisplayName = displayAttribute == null ? propertyInfo.Name : displayAttribute.DisplayName,
                    Value = propertyInfo.GetValue(obj).ToString(),
                    IsMandatory = isRequired,
                    MandatoryValidationMessage = isRequired ? "This field is required" : string.Empty,
                    ReadOnly = readOnlyAttribute?.IsReadOnly ?? false
                });
            }

            return form;
        }

        private T GetAttributeFrom<T>(object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).FirstOrDefault();
        }
    }
}
