using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private static List<Feedback> feedbackList = new List<Feedback>();

        // Customer Feedback Page
        public ActionResult Create()
        {
            return View();
        }

        // Submit Feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = feedbackList.Count + 1;
                feedback.Date = DateTime.Now;

                feedbackList.Add(feedback);

                TempData["Success"] = "Thank you! Your feedback has been submitted successfully.";

                return RedirectToAction("Create");
            }

            return View(feedback);
        }

        // Management/Admin Page
        public ActionResult Index()
        {
            return View(feedbackList);
        }
    }
}