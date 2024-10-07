using System.Collections.Generic;

namespace FormsTest.Models.Form
{
    public class Form
    {
        public IList<FormField> Fields { get; set; } = new List<FormField>();
    }
}
