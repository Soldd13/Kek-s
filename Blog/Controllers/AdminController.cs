using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Blog.Models.Db;

namespace Blog.Controllers
{

    public class AdminController : Controller
    {
        private db79cd0e6f5c6640c28100a29900dde70aEntities db = new db79cd0e6f5c6640c28100a29900dde70aEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string pass)
        {
            if (ModelState.IsValid)
            {
                Session["IsApply"] = false;

                if (pass.Equals("kek-s"))
                {
                    Session["IsApply"] = true;
                }
            }

            return View();
        }



        #region Events
        //-----Events-----

        #endregion

        public ActionResult EventsTable()
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                return View(db.Events.ToList());
            }
            return RedirectToAction("Index");
        }

        public ActionResult DetailsEvent(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                var events = db.Events.Find(id);
                if (events == null)
                {
                    return HttpNotFound();
                }
                return View(events);
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateEvent()
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(Events events)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                if (ModelState.IsValid)
                {
                    events.Date = DateTime.Now;
                    db.Events.Add(events);
                    db.SaveChanges();
                    return RedirectToAction("EventsTable");
                }

                return View(events);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditEvent(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Events events = db.Events.Find(id);
                if (events == null)
                {
                    return HttpNotFound();
                }
                return View(events);
            }
            return RedirectToAction("Index");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(Events events)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                if (ModelState.IsValid)
                {
                    db.Entry(events).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("EventsTable");
                }
                return View(events);
            }
            return RedirectToAction("Index");

        }

        public ActionResult DeleteEvent(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Events events = db.Events.Find(id);
                if (events == null)
                {
                    return HttpNotFound();
                }
                return View(events);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedEvent(int id)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Events notes = db.Events.Find(id);
                db.Events.Remove(notes);
                var deleteComNone =
                          from idComm in db.EventsComments
                          where idComm.IdComm == id
                          select idComm;
                foreach (var idComm in deleteComNone)
                {
                    db.EventsComments.Remove(idComm);
                }
                db.SaveChanges();
                return RedirectToAction("EventsTable");
            }
            return RedirectToAction("Index");

        }


        //------NOTES-----

        public ActionResult NotesTable()
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {

                return View(db.Notes.ToList());
            }
            return RedirectToAction("Index");
        }

        public ActionResult DetailsNote(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                var notes = db.Notes.Find(id);
                if (notes == null)
                {
                    return HttpNotFound();
                }
                return View(notes);
            }
            return RedirectToAction("Index");

        }

        public ActionResult CreateNote()
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                return View();
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNote(Notes notes)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                if (ModelState.IsValid)
                {
                    notes.Date = DateTime.Now;
                    db.Notes.Add(notes);
                    db.SaveChanges();
                    return RedirectToAction("NotesTable");
                }
                return View(notes);
            }
            return RedirectToAction("Index");

        }

        public ActionResult EditNote(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Notes notes = db.Notes.Find(id);
                if (notes == null)
                {
                    return HttpNotFound();
                }
                return View(notes);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNote(Notes notes)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                if (ModelState.IsValid)
                {
                    db.Entry(notes).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("NotesTable");
                }
                return View(notes);
            }
            return RedirectToAction("Index");

        }

        public ActionResult DeleteNote(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Notes notes = db.Notes.Find(id);
                if (notes == null)
                {
                    return HttpNotFound();
                }
                return View(notes);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedNote(int id)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Notes notes = db.Notes.Find(id);
                db.Notes.Remove(notes);
                var deleteComNone =
                          from idComm in db.NotesComments
                          where idComm.IdComm == id
                          select idComm;
                foreach (var idComm in deleteComNone)
                {
                    db.NotesComments.Remove(idComm);
                }
                db.SaveChanges();
                return RedirectToAction("NotesTable");
            }
            return RedirectToAction("Index");

        }






        //------PHOTOS-----
        public ActionResult PhotosTable()
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {

                return View(db.Photos.ToList());
            }
            return RedirectToAction("Index");
        }

        public ActionResult DetailsPhoto(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                var photos = db.Photos.Find(id);
                if (photos == null)
                {
                    return HttpNotFound();
                }
                return View(photos);
            }
            return RedirectToAction("Index");

        }

        public ActionResult CreatePhoto()
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhoto(Photos photos)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                if (ModelState.IsValid)
                {
                    photos.Date = DateTime.Now;
                    db.Photos.Add(photos);
                    db.SaveChanges();
                    return RedirectToAction("PhotosTable");
                }

                return View(photos);
            }
            return RedirectToAction("Index");

        }

        public ActionResult EditPhoto(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Photos photos = db.Photos.Find(id);
                if (photos == null)
                {
                    return HttpNotFound();
                }
                return View(photos);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPhoto(Photos photos)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                if (ModelState.IsValid)
                {
                    db.Entry(photos).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("PhotosTable");
                }
                return View(photos);
            }
            return RedirectToAction("Index");

        }

        public ActionResult DeletePhoto(int id = 0)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Photos photos = db.Photos.Find(id);
                if (photos == null)
                {
                    return HttpNotFound();
                }
                return View(photos);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPhoto(int id)
        {
            if (Session["IsApply"] != null && (bool)Session["IsApply"])
            {
                Photos notes = db.Photos.Find(id);
                db.Photos.Remove(notes);
                var deleteComNone =
                          from idComm in db.PhotosComments
                          where idComm.IdComm == id
                          select idComm;
                foreach (var idComm in deleteComNone)
                {
                    db.PhotosComments.Remove(idComm);
                }
                db.SaveChanges();
                return RedirectToAction("PhotosTable");
            }
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}