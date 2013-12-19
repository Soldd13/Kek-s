using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.Models.Db;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private db79cd0e6f5c6640c28100a29900dde70aEntities db = new db79cd0e6f5c6640c28100a29900dde70aEntities();

        public ActionResult Index()
        {
            var events = db.Events.Where(x => x.Id > 0).ToList();
            var notes = db.Notes.Where(x => x.Id > 0).ToList();
            notes.Reverse();
            events.Reverse();
            ViewBag.Events = events;
            ViewBag.Notes = notes;
            return View();

        }

        public ActionResult Events()
        {
            var events = db.Events.Where(x => x.Id > 0).ToList();
            events.Reverse();
            ViewBag.Events = events;
            return View();
        }

        public ActionResult Photos()
        {
            var photos = db.Photos.Where(x => x.Id > 0).ToList();
            photos.Reverse();
            ViewBag.Photos = photos;
            return View();
        }

        public ActionResult Autobiography()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCommentNote(int Id, string Name, string Message, string Page)
        {
            if (ModelState.IsValid)
            {
                var firstOrDefaultNote = db.Notes.FirstOrDefault(x => x.Id == Id);
                if (firstOrDefaultNote != null)
                    firstOrDefaultNote.NotesComments.Add(new NotesComments
                    {
                        Date = DateTime.Now,
                        Name = Name,
                        Message = Message,
                    });
                db.SaveChanges();
            }
            if (Page != "ViewComments")
            {
                return (RedirectToAction("Index"));
            }
            return RedirectToAction("ViewCommentsNote", null, new { id = Id });
        }

        public ActionResult AddCommentEvent(int Id, string Name, string Message, string Page)
        {
            if (ModelState.IsValid)
            {
                var firstOrDefaultEvent = db.Events.FirstOrDefault(x => x.Id == Id);
                if (firstOrDefaultEvent != null)
                    firstOrDefaultEvent.EventsComments.Add(new EventsComments
                    {
                        Date = DateTime.Now,
                        Name = Name,
                        Message = Message,
                    });
                db.SaveChanges();
            }
            if (Page != "ViewComments")
            {
                return (RedirectToAction("Events"));
            }
            return RedirectToAction("ViewCommentsEvent", null, new { id = Id });
        }


        public ActionResult AddCommentPhoto(int Id, string Name, string Message, string Page)
        {
            if (ModelState.IsValid)
            {
                var firstOrDefaultPhoto = db.Photos.FirstOrDefault(x => x.Id == Id);
                if (firstOrDefaultPhoto != null)
                    firstOrDefaultPhoto.PhotosComments.Add(new PhotosComments()
                    {
                        Date = DateTime.Now,
                        Name = Name,
                        Message = Message,
                    });
                db.SaveChanges();
            }
            if (Page != "ViewComments")
            {
                return (RedirectToAction("Photos"));
            }
            return RedirectToAction("ViewCommentsPhoto", null, new {id = Id});
        }


        public ActionResult ViewCommentsNote(int Id)
        {

            var item = db.Notes.FirstOrDefault(x => x.Id == Id);
            ViewBag.Item = item;
            var comments = db.NotesComments.Where(x => x.IdComm == Id).ToList();
            ViewBag.Comments = comments;
            return View();
        }


        public ActionResult ViewCommentsEvent(int Id)
        {

            var item = db.Events.FirstOrDefault(x => x.Id == Id);
            ViewBag.Item = item;
            var comments = db.EventsComments.Where(x => x.IdComm == Id).ToList();
            ViewBag.Comments = comments;
            return View();
        }

        public ActionResult ViewCommentsPhoto(int Id)
        {

            var item = db.Photos.FirstOrDefault(x => x.Id == Id);
            ViewBag.Item = item;
            var comments = db.PhotosComments.Where(x => x.IdComm == Id).ToList();
            ViewBag.Comments = comments;
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
