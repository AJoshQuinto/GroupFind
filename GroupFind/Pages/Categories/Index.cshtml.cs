using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupFind.Data;
using GroupFind.Data.Models;

namespace GroupFind.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly GroupFind.Data.ApplicationDbContext _context;

        public IndexModel(GroupFind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GroupFind.Data.Models.Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
