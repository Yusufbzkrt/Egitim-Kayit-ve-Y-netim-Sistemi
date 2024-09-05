using Microsoft.AspNetCore.Mvc;
using MvcProject.Data;
using MvcProject.Models;


namespace MvcProject.Controllers
{
	public class CourseController : Controller
	{
        private readonly CourseDbContext _context;
        public CourseController(CourseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
			var adaylar = _context.Adaylar.ToList();
			return View(adaylar);
		}
		public IActionResult Apply()
		{
			return View(new Aday());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]// CSRF saldırılarına karşı korumak için kullanılır.
		public IActionResult Apply(Aday aday)
		{
            if (ModelState.IsValid)
            {
                bool emailexists = _context.Adaylar.Any(a=> a.Email == aday.Email);
                if (emailexists)
                {
                    // E-posta adresi zaten mevcut
                    ModelState.AddModelError("Email", "Bu e-posta adresi zaten kayıtlı.");
                    return View(aday);
                }
                _context.Adaylar.Add(aday);
                _context.SaveChanges();
                return View("Feedback", aday);
            }

            // Model geçersizse, formu tekrar göster
            return View(aday);
        }
        public IActionResult CourseDelete(int id)
        {
            var entity = _context.Adaylar.Find(id);
            if(entity != null)
            {
                _context.Adaylar.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult CourseUpdate(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var entity = _context.Adaylar.Select(m => new UpdateAday
            {
                Id = m.Id,
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Age = m.Age,
                SelectedCourse = m.SelectedCourse,
                ApplyAt = m.ApplyAt
            }).FirstOrDefault(m => m.Id == id);
			ViewBag.Genres = _context.Adaylar.ToList();

			if (entity == null)
			{
				return NotFound();
			}
			return View(entity);

		}

        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CourseUpdate(UpdateAday aday)
        {
			if (ModelState.IsValid)
			{
				var entity = _context.Adaylar.Find(aday.Id);

				if (entity == null)
				{
					return NotFound();
				}

				// Mevcut aday bilgilerini güncelle
				entity.FirstName = aday.FirstName;
				entity.LastName = aday.LastName;
				entity.Email = aday.Email;
				entity.Age = aday.Age;
				entity.SelectedCourse = aday.SelectedCourse;

				_context.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(aday);
		}
	}
}
 