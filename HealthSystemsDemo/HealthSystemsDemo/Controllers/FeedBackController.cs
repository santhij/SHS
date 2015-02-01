using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthSystemsDemo.Models;

namespace HealthSystemsDemo.Controllers
{
    public class FeedBackController : Controller
    {
        private SHSModel db = new SHSModel();

        // GET: /FeedBack/
         [Authorize]
        public ActionResult Index()
        {
            var feebacks = db.Feedbacks.Include(f => f.Industry);
             var avg = feebacks.Average(u => u.ServiceRating);
             ViewBag.Average = Math.Round(avg, 2); 
            return View(feebacks.ToList());
        }

        // GET: /FeedBack/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feeback = db.Feedbacks.Find(id);
            if (feeback == null)
            {
                return HttpNotFound();
            }
            return View(feeback);
        }

        // GET: /FeedBack/Create
         [Authorize]
        public ActionResult Create()
        {
            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "Description");
            return View();
        }


         // GET: /FeedBack/Create
         [Authorize]
         public ActionResult ThankYou()
         {
             ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "Description");
             return View();
         }


        // POST: /FeedBack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId,IndustryId,MainFeature,ServiceRating,AreaOfImprovement,FurtherFeedback")] Feedback feedback, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                var user = System.Web.HttpContext.Current.User;
                feedback.UserId = user.Identity.Name;
                feedback.ServiceRating = (frm != null)? Convert.ToInt32(frm["rbGrp"]) :1;
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("ThankYou");
            }

            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "Description", feedback.IndustryId);
            return View(feedback);
        }

        // GET: /FeedBack/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feeback = db.Feedbacks.Find(id);
            if (feeback == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "Description", feeback.IndustryId);
            return View(feeback);
        }

        // POST: /FeedBack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId,IndustryId,MainFeature,ServiceRating,AreaOfImprovement,FurtherFeedback")] Feedback feeback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "Description", feeback.IndustryId);
            return View(feeback);
        }

        // GET: /FeedBack/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feeback = db.Feedbacks.Find(id);
            if (feeback == null)
            {
                return HttpNotFound();
            }
            return View(feeback);
        }

        // POST: /FeedBack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feeback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feeback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
