using System.Reflection;

namespace FormsTest.Models.Form
{
    public class TypedFormFieldSource<TType, TExpression>
    {
        public PropertyInfo PropertyInfo { get; set; }

        public TExpression Expression { get; set; } 

        public IEnumerable<string> Options { get; set; }
    }
}
