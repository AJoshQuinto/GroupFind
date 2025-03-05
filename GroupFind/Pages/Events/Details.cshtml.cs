using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupFind.Data;
using GroupFind.Data.Models;

namespace GroupFind.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly GroupFind.Data.ApplicationDbContext _context;

        public DetailsModel(GroupFind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _context.Event.FirstOrDefaultAsync(m => m.EventID == id);
            if (eventItem == null)
            {
                return NotFound();
            }
            else
            {
                Event = eventItem;
            }
            return Page();
        }
    }
    }
