using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GroupFind.Data.Models;
using GroupFind.Data;

public class EventController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Events
    public async Task<IActionResult> Index(string search)
    {
        var events = from e in _context.Event.Include(e => e.Category).Include(e => e.User)
                     select e;

        if (!string.IsNullOrEmpty(search))
        {
            events = events.Where(e => e.EventTitle.Contains(search) || e.City.Contains(search) || e.Country.Contains(search));
        }

        ViewData["SearchQuery"] = search;
        return View(await events.ToListAsync());
    }

    // GET: Events/Details/{eventTitle}
    public async Task<IActionResult> Details(string eventTitle)
    {
        if (string.IsNullOrEmpty(eventTitle))
        {
            return NotFound();
        }

        var eventItem = await _context.Event
            .Include(e => e.Category)
            .Include(e => e.User)
            .FirstOrDefaultAsync(m => m.EventTitle == eventTitle);

        if (eventItem == null)
        {
            return NotFound();
        }

        return View(eventItem);
    }
}
