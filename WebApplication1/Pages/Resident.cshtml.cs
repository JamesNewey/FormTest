using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FormsTest.Models;

namespace FormsTest.Pages
{
    public class ResidentModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Resident Resident { get; set; }

        public ResidentModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Resident = new Resident()
            {
                Name = "James"
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var thing = Resident.Name;

            //if (Resident != null) _context.Customer.Add(Customer);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}