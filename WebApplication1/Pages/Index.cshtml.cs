using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FormsTest.Models;
using FormsTest.Models.Form;
using FormsTest.Services;

namespace FormsTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        private readonly IFormService _formService;

        [BindProperty]
        public Form Form { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IFormService formService)
        {
            _formService = formService;
            _logger = logger;
        }

        public void OnGet()
        {
            var resident = new Resident()
            {
                Id = 1,
                Name = "James"
            };

            Form = _formService.GetForm(resident);
        }

        public async Task<IActionResult> OnPostAsync(Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var thing = Form;

            //if (Resident != null) _context.Customer.Add(Customer);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}