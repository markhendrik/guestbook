using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GuestBook.Dto;
using GuestBook.Models;
using GuestBook.ViewModels;

namespace GuestBook.Controllers
{
    public class GuestsController : Controller
    {
        private ApplicationDbContext _context;

        public GuestsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Guests
        public ActionResult CreateBusinessClientApi()
        {
            return View("GuestBusinessFormApi");
        }

        /// <summary>
        /// Controller redirecting to form of Business Client.
        /// </summary>
        /// <returns>Business specific form.</returns>
        public ActionResult CreateBusinessClient()
        {
            var paymentTypes = _context.PaymenTypes.ToList();
            var viewModel = new GuestFormViewModel
            {
                PaymentTypes = paymentTypes
            };

            return View("GuestBusinessForm", viewModel);
        }

        /// <summary>
        /// Redirection to client creation form by client type.
        /// </summary>
        /// <param name="clientType">Client type whether 'private' or 'business'</param>
        /// <returns></returns>
        public ActionResult CreateClient(string clientType)
        { 
            var paymentTypes = _context.PaymenTypes.ToList();
            var viewModel = new GuestFormViewModel
            {
                PaymentTypes = paymentTypes,
                NumberGuests = 1

            };

            var form = clientType == "business" ? "GuestBusinessForm" : "GuestPrivateForm";

            return View(form, viewModel);
        }

        
        /// <summary>
        /// Saving Business Client by Guest's DTO.
        /// </summary>
        /// <param name="guestDto">DTO of saving data</param>
        /// <returns>View to same form.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SaveBusinessClient(NewGuestDto guestDto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GuestFormViewModel()
                {
                    PaymentTypes = _context.PaymenTypes.ToList()
                };
                return View("GuestBusinessForm", viewModel);
            }

            var guest = Mapper.Map<NewGuestDto, Guest>(guestDto);
            guest.PaymentType = _context.PaymenTypes.Single(pt => pt.Id == guestDto.PaymentTypeId);
            guest.GuestType = _context.GuestTypes.Single(gt => gt.Id == GuestTypeNames.BusinessClient);

            _context.Guests.Add(guest);
            _context.SaveChanges();

            return RedirectToAction("CreateClient", "Guests", new { clientType = "business" });
        }


        /// <summary>
        /// Saving Private Client by Guest's DTO.
        /// </summary>
        /// <param name="guestDto">DTO of saving data</param>
        /// <returns>View to same form.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SavePrivateClient(NewGuestDto guestDto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GuestFormViewModel()
                {
                    PaymentTypes = _context.PaymenTypes.ToList()
                };
                return View("GuestPrivateForm", viewModel);
            }

            var guest = Mapper.Map<NewGuestDto, Guest>(guestDto);
            guest.PaymentType = _context.PaymenTypes.Single(pt => pt.Id == guestDto.PaymentTypeId);
            guest.GuestType = _context.GuestTypes.Single(gt => gt.Id == GuestTypeNames.PrivateClient);
            guest.NumberGuests = GuestTypeNames.PrivateClientNumOfParticipants;

            _context.Guests.Add(guest);
            _context.SaveChanges();

            return RedirectToAction("CreateClient", "Guests", new { clientType = "private"});
        }
    }
}