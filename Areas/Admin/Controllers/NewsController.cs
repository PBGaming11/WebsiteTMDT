using Microsoft.AspNetCore.Mvc;
using WebsiteTMDT.Areas.Admin.Models.EF;
using WebsiteTMDT.Data;

namespace WebsiteTMDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NewsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var item = _db.News.OrderByDescending(x => x.Id).ToList();
            return View(item);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(New model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            model.CreateDate = DateTime.Now;
            model.ModifierDate = DateTime.Now;
            model.CategoryId = 5;
            model.Alias = WebsiteTMDT.Areas.Admin.Models.Common.Filter.FilterChar(model.Title);
            _db.News.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var item = _db.News.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(New model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            model.ModifierDate = DateTime.Now;
            model.Alias = WebsiteTMDT.Areas.Admin.Models.Common.Filter.FilterChar(model.Title);
            _db.News.Attach(model);
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _db.News.Find(id);
            if(item != null)
            {
                _db.News.Remove(item);
                _db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
