using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;
using System.Xml.Linq;

namespace SeminarHub.Controllers
{
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;
        public SeminarController(SeminarHubDbContext _data)
        {
            data= _data;
        }
        public async Task<IActionResult> All()
        {
            var seminars = await data.Seminars
                .Select(s => new SeminarInfoViewModel()
                {
                    Id=s.Id,
                    Topic=s.Topic,
                    Lecturer=s.Lecturer,
                    Category=s.Category.Name,
                    DateAndTime=s.DateAndTime.ToString(DataConstants.DateFormat),
                    Organizer=s.Organizer.UserName
                }
                ).ToListAsync();
            return View(seminars);
        }
        public async Task<IActionResult> Join(int id)
        {
            var seminartoAdd = await data.Seminars.FindAsync(id);
            if (seminartoAdd == null)
            {
                return BadRequest();
            }
            string user = GetUserId();
            var entry = new SeminarParticipant()
            {
                SeminarId = id,
                ParticipantId = user
            };
            if (await data.SeminarsParticipants.ContainsAsync(entry))
            {
                return RedirectToAction("All");
            }
            await data.SeminarsParticipants.AddAsync(entry);
            await data.SaveChangesAsync();
            return RedirectToAction("Joined", "Seminar");
        }
        public async Task<IActionResult> Joined()
        {
            string curentUser = GetUserId();
            var usersSeminars = await data
                .SeminarsParticipants
                .Where(sp => sp.ParticipantId == curentUser)
                .Select(sp => new SeminarViewModel()
                {
                    Id = sp.Seminar.Id,
                    Topic = sp.Seminar.Topic,
                    Category = sp.Seminar.Category.Name,
                    DateAndTime = sp.Seminar.DateAndTime.ToString(DataConstants.DateFormat),
                    Lecturer = sp.Seminar.Lecturer,
                    Organizer = sp.Seminar.Organizer.UserName
                }).ToListAsync();

            return View(usersSeminars);
        }
        public async Task<IActionResult> Leave(int id)
        {
            var seminartoAdd = await data.Seminars.FindAsync(id);
            if (seminartoAdd == null)
            {
                return BadRequest();
            }
            var user = GetUserId();
            var entry = await data.SeminarsParticipants.FirstOrDefaultAsync(sp => sp.SeminarId == id && sp.ParticipantId == user);
            data.SeminarsParticipants.Remove(entry);
            await data.SaveChangesAsync();
            return RedirectToAction("Joined", "Seminar");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var seminartoEdit=data.Seminars.FindAsync(id);
            if (seminartoEdit==null)
            {
                return BadRequest();
            }
            var user = GetUserId();
            if (user!=seminartoEdit.Result.OrganizerId)
            {
                return Unauthorized();
            }
            SeminarEditView seminarModel = new SeminarEditView()
            {
                Topic = seminartoEdit.Result.Topic,
                Lecturer = seminartoEdit.Result.Lecturer,
                Details = seminartoEdit.Result.Details,
                DateAndTime = seminartoEdit.Result.DateAndTime.ToString(DataConstants.DateFormat),
                Duration = seminartoEdit.Result.Duration,
                CategoryId = seminartoEdit.Result.Id,
                Categories = GetCategories()
            };
            return View(seminarModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,SeminarEditView seminarModel)
        {
            var seminartoEdit = await data.Seminars.FindAsync(id);
            if (seminartoEdit == null)
            {
                return BadRequest();
            }
            var user = GetUserId();
            if (user != seminartoEdit.OrganizerId)
            {
                return Unauthorized();
            }
            if (!GetCategories().Any(e => e.Id == seminarModel.CategoryId))
            {
                ModelState.AddModelError(nameof(seminarModel.CategoryId), "Category does not exist!");
            }
            DateTime time=DateTime.Now;
            if (!DateTime.TryParseExact(seminarModel.DateAndTime,DataConstants.DateFormat,CultureInfo.InvariantCulture,DateTimeStyles.None,out time))
            {
                ModelState
                   .AddModelError(nameof(seminarModel.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }
            seminartoEdit.Topic=seminarModel.Topic;
            seminartoEdit.Lecturer=seminarModel.Lecturer;
            seminartoEdit.Details=seminarModel.Details;
            seminartoEdit.DateAndTime = time;
            seminartoEdit.Duration=seminarModel.Duration;
            seminartoEdit.CategoryId=seminarModel.CategoryId;
            await data.SaveChangesAsync();
            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            SeminarEditView seminarAdd = new SeminarEditView()
            {
                Categories = GetCategories()
            };
            return View(seminarAdd);
        }
        [HttpPost]
        public async Task<IActionResult> Add(SeminarEditView seminarAd)
        {
            if (!GetCategories().Any(e => e.Id == seminarAd.CategoryId))
            {
                ModelState.AddModelError(nameof(seminarAd.CategoryId), "Category does not exist!");
            }
            if (!ModelState.IsValid)
            {
                return View(seminarAd);
            }
            string cuurentUser = GetUserId();
            DateTime time = DateTime.Now;
            if (!DateTime.TryParseExact(seminarAd.DateAndTime, DataConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
            {
                ModelState
                   .AddModelError(nameof(seminarAd.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }
            var seminarToAdd = new Seminar()
            {
                Topic = seminarAd.Topic,
                Lecturer = seminarAd.Lecturer,
                Details = seminarAd.Details,
                DateAndTime = time,
                Duration = seminarAd.Duration,
                CategoryId = seminarAd.CategoryId,
                OrganizerId = cuurentUser,
            };
            await data.Seminars.AddAsync(seminarToAdd);
            await data.SaveChangesAsync();
            return RedirectToAction("All");
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarDetailsModel()
                {
                    Id= s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat),
                    Duration = s.Duration,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    Details = s.Details,
                    Organizer = s.Organizer.UserName
                }).FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
        private IEnumerable<CategoryViewModel> GetCategories()
            => data
                .Categories
                .Select(t => new CategoryViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                });
        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
