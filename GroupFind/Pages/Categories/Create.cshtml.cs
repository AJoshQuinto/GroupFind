using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupFind.Data;
using GroupFind.Data.Models;

namespace GroupFind.Pages.Category
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
            return Page();
        }
        private GroupFind.Data.Models.Category category = default!; 

        public GroupFind.Data.Models.Category GetCategory() 
        {
            return category;
        }

        public void SetCategory(GroupFind.Data.Models.Category value) 
        {
            category = value;
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(GetCategory());
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
