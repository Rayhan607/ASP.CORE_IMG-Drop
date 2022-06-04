using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using WebApplication5.Models;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
    public class EmpController : Controller
    {
        EmpDbContext db;
        IWebHostEnvironment evn;

        private readonly ILogger<EmpController> _logger;

        public EmpController(ILogger<EmpController> logger, EmpDbContext db, IWebHostEnvironment evn)
        {
            _logger = logger;
            this.db = db;
            this.evn= evn;

        }
        public IActionResult Index()
        {
            return View(db.Emps.Include(x=>x.Dep).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Drop = db.Deps.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EidtInput e)
        {
            if (ModelState.IsValid)
            {
                var emp = new Emp
                {                          
                    EmpName = e.EmpName,
                    DepId = e.DepId,
                };
              
                var ext = Path.GetExtension(e.EmpImg.FileName);
                var f = Guid.NewGuid() + ext;
                e.EmpImg.CopyTo(new FileStream(evn.WebRootPath + "\\Upload\\" + f, FileMode.Create));
                emp.EmpImg= f;

                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Drop = db.Deps.ToList();
            return View();
        }
        public IActionResult Eidt(int id)
        {
            var data = db.Emps.First(x => x.EmpId == id);
            ViewBag.Drop = db.Deps.ToList();
            ViewBag.EmpImg = data.EmpImg;

            return View(new EmpEidt
            {
                EmpName =data.EmpName,
                EmpId = data.EmpId,
                DepId = data.DepId,
                //EmpImg=data.EmpImg,
            });
        }
        [HttpPost]
        public IActionResult Eidt(EmpEidt e)
        {
            var sata = db.Emps.First(x=>x.EmpId == e.EmpId);
            ViewBag.EmpImg = sata.EmpImg;
            ViewBag.Drop = db.Deps.ToList();
            if (ModelState.IsValid)
            {
                sata.EmpName = e.EmpName;
                sata.EmpId = e.EmpId;
                sata.DepId = e.DepId;
                if ( e.EmpImg != null)
                {
                    var ext = Path.GetExtension(e.EmpImg.FileName);
                    var f =  Guid.NewGuid()  +  ext;
                    e.EmpImg.CopyTo(new FileStream(evn.WebRootPath + "\\Upload\\" + f, FileMode.Create));
                    sata.EmpImg = f;
                }
            }
            db.Entry(sata).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            db.Entry(new Emp { EmpId = id}).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
