using System.Linq.Expressions;
using FormsTest.Models.Form;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FormsTest.Services
{
    public class FormFieldBuilder<TModel, TProp>
    {
        protected Form _form;

        protected readonly TModel _model;


        public FormFieldBuilder()
        {
            
        }

        public FormFieldBuilder(TModel model)
        {

            _form = new Form();
            _model = model;
        }

        //public FormFieldBuilder<TModel, TProp> AddProperty<TProp>(Expression<Func<TModel, TProp>> property)
        //{
        //    return this;
        //}

        public FormFieldBuilder<TModel, TProp> SelectWithOptions(IEnumerable<string> options)
        {
            return this;
        }
    }
}
