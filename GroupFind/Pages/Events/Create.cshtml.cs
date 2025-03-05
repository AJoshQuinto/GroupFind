using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupFind.Data;
using GroupFind.Data.Models;

namespace GroupFind.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly GroupFind.Data.ApplicationDbContext _context;

        public CreateModel(GroupFind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName");
        ViewData["CreatorID"] = new SelectList(_context.Set<User>(), "UserID", "EmailAddress");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Event.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
