using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{

    public class DepController : Controller
    {
        EmpDbContext db;
        
        private readonly ILogger<DepController> _logger;

        public DepController(ILogger<DepController> logger, EmpDbContext db)
        {
            _logger = logger;
            this.db = db;
          
        }
        public IActionResult Index()
        {
            return View(db.Deps.Include(x=>x.Emps).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dep d)
        {
            if (ModelState.IsValid)
            {
                db.Deps.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.drop = db.Deps.ToList();
            return View();
        }
        public IActionResult Eidt(int id)
        {
            var data = db.Deps.First(x=>x.DepId == id);
            return View(data);

        }
        [HttpPost]
        public IActionResult Eidt(Dep d)
        {
            if (ModelState.IsValid)
            {
                db.Entry(d).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }         
            return View(d);
        }
        public IActionResult Delete(int id)
        {

                db.Entry(new Dep { DepId = id }).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }



    }
}
