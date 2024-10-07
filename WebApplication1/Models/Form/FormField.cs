namespace FormsTest.Models.Form
{
    public class FormField
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public object Value { get; set; }

        public bool IsMandatory { get; set; }

        public string MandatoryValidationMessage { get; set; }

        public bool ReadOnly { get; set; }
    }
}
