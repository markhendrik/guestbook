using GuestBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GuestBook.Models;
using System.Data.Entity;

namespace GuestBook.Controllers.Api
{
    public class GuestsController : ApiController
    {
        private ApplicationDbContext _context;

        public GuestsController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/guests/{query}
        /// <summary>
        /// Get Guests by name or name's substring.
        /// </summary>
        /// <param name="query">Name or its part of Guest</param>
        /// <returns>Guest's Data Transfer Object of every found Guest</returns>
        public IHttpActionResult GetGuests(string query = null)
        {
            var guestsQuery = _context.Guests.Include(g => g.GuestType).Include(g => g.PaymentType);

            if (!String.IsNullOrWhiteSpace(query))
                guestsQuery = guestsQuery.Where(c => c.Name.Contains(query));

            var guestsDtos = guestsQuery
                .ToList()
                .Select(Mapper.Map<Guest, NewGuestDto>);

            return Ok(guestsDtos);
        }


        //GET /api/guests/1
        /// <summary>
        /// Get Guest by id
        /// </summary>
        /// <param name="id">Id of Guest</param>
        /// <returns>Found Guest's DTO</returns>
        public IHttpActionResult GetGuest(int id)
        {
            var guest = _context.Guests.SingleOrDefault(g => g.Id == id);

            if (guest == null)
                return NotFound();
            return Ok(Mapper.Map<Guest, NewGuestDto>(guest));
        }

        /// <summary>
        /// Create Guest according to posted DTO. 
        /// </summary>
        /// <param name="newGuest">Posted Guest's DTO form</param>
        /// <returns>Created Guest details</returns>
        [HttpPost]
        public IHttpActionResult CreateGuest(NewGuestDto newGuest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guest = Mapper.Map<NewGuestDto, Guest>(newGuest);
            
            guest.GuestType = _context.GuestTypes.Single(gt => gt.Id == newGuest.GuestTypeId);
            guest.PaymentType = _context.PaymenTypes.Single(gt => gt.Id == newGuest.PaymentTypeId);

            _context.Guests.Add(guest);
            _context.SaveChanges();

            newGuest.Id = guest.Id;
            return Created(new Uri(Request.RequestUri + "/" + guest.Id), newGuest);
        }
    }
}
