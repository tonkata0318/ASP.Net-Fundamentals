using Homies.Data;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext data;

        public EventController(HomiesDbContext _data)
        {
            data = _data;
        }

        public async Task<IActionResult> All()
        {
            var events = await data.Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel
                (
                    e.Id,
                    e.Name,
                    e.Start,
                    e.Type.Name,
                    e.Organiser.UserName
                )
                ).ToListAsync();

            return View(events);
        }
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var e = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventParticipants)
                .FirstOrDefaultAsync();

            if (e==null)
            {
                return BadRequest();
            }

            string userId=GetUserId();

            if (!e.EventParticipants.Any(p=>p.HelperId==userId))
            {
                e.EventParticipants.Add(new EventParticipant()
                {
                    EventId = id,
                    HelperId = userId
                });
                await data.SaveChangesAsync();
            }
            return RedirectToAction("Joined");
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
