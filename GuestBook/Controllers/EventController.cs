using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuestBook.Models;
using GuestBook.ViewModels;

namespace GuestBook.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Controller redirecting to form of new event.
        /// </summary>
        /// <returns>View with empty form.</returns>
        public ActionResult New()
        {
            var viewModel = new EventFormViewModel
            {
                Guests = new List<Guest>(),
            };
            return View(viewModel);
        }

        /// <summary>
        /// Determine whether to get View with past event or present ones.
        /// </summary>
        /// <param name="isPassed">Determine if event was in the past</param>
        /// <returns>View wtih events</returns>
        public ActionResult Index(bool isPassed = false)
        {
            var events = _context.Events.ToList();
            var today = DateTime.Today;
            events = isPassed ? events.Where(e => e.DateEnd < today).ToList() : events.Where(e => e.DateEnd > today).ToList();
            return View(events);
        }

        /// <summary>
        /// Controller redirecting to form for editing event by id.
        /// </summary>
        /// <param name="id">ID of Event</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var eventInDb = _context.Events.Single(e => e.Id == id);

            var viewModel = new EventFormViewModel
            {
                Name = eventInDb.Name,
                Address = eventInDb.Address,
                DateBeg = eventInDb.DateBeg,
                DateEnd = eventInDb.DateEnd,
                Information = eventInDb.Information,
                Guests = _context.GuestOfEvents.Where(ge => ge.Event.Id == id).Select(ge => ge.Guest).ToList(),
                IsNewForm = false,
                Id = eventInDb.Id
            };
            return View("Edit", viewModel);
        }
    }
}