using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astroworld.Controllers
{
    public class CommentsController : Controller
    {
        private Astroworld.Models.CommentsContext _db = new Astroworld.Models.CommentsContext();

        public ActionResult Index()
        {
            var mostRecentEntries =
                (from entry in _db.Entries
                 orderby entry.DateAdded descending
                 select entry).Take(20);
            ViewBag.Entries = mostRecentEntries.ToList();
            return View();
        }

        // GET: Comments
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Astroworld.Models.Comments entry)
        {
            entry.DateAdded = DateTime.Now;
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult Show(int id)
        {
            var entry = _db.Entries.Find(id);
            bool HasPermission = true; //User.Identity.Name == entry.Name;
            ViewData["hasPermission"] = HasPermission;
            ViewBag.HasPermission = HasPermission;
            return View(entry);
        }

        public ActionResult CommentSummary()
        {
            var entries = from entry in _db.Entries
                          group entry by entry.Name
                          into groupedByName
                          orderby groupedByName.Count() descending

                          select new Astroworld.Models.CommentSummary
                          {
                              NumberOfComments = groupedByName.Count(),
                              UserName = groupedByName.Key
                          };
                          return View(entries.ToList());
        }

    }
}