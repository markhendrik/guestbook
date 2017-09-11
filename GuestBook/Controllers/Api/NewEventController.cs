using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GuestBook.Models;
using GuestBook.Dto;

namespace GuestBook.Controllers.Api
{
    public class NewEventController : ApiController
    {
        private ApplicationDbContext _context;

        public NewEventController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Create a new Event according to posted DTO.
        /// </summary>
        /// <param name="newEvent">Posted Event's DTO form</param>
        /// <returns>Status code 200</returns>
        [HttpPost]
        public IHttpActionResult CreateNewEvent(NewEventDto newEvent)
        {
            var eventToDb = Mapper.Map<NewEventDto, Event>(newEvent);


            var guests = _context.Guests.Where(g => newEvent.GuestsIds.Contains(g.Id)).ToList();
            int? totalGuests = 0;

            foreach (var guest in guests)
            {
                if (guest.NumberGuests != null)
                {
                    totalGuests += guest.NumberGuests;
                }
                var guestsOfEvent = new GuestOfEvent {Event = eventToDb, Guest = guest};
                _context.GuestOfEvents.Add(guestsOfEvent);
            }
            eventToDb.NumberGuestsTotal = totalGuests;
            _context.Events.Add(eventToDb);
            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Edit Event by its ID and posted DTO.
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <param name="eventDto">DTO of edited data</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult EditEvent(int id, NewEventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var eventInDb = _context.Events.Single(e => e.Id == id);

            if (eventInDb == null)
                NotFound();
            Mapper.Map<NewEventDto, Event>(eventDto, eventInDb);

            // Remove previous Guests
            _context.GuestOfEvents.Where(ge => ge.Event.Id == id).ToList()
                .ForEach(ge => _context.GuestOfEvents.Remove(ge));

            var newGuests = _context.Guests.Where(g => eventDto.GuestsIds.Contains(g.Id)).ToList();

            int? totalGuests = 0;
            foreach (var guest in newGuests)
            {
                if (guest.NumberGuests != null)
                {
                    totalGuests += guest.NumberGuests;
                }
                var guestsOfEvent = new GuestOfEvent {Event = eventInDb, Guest = guest};
                _context.GuestOfEvents.Add(guestsOfEvent);
            }
            eventInDb.NumberGuestsTotal = totalGuests;

            _context.SaveChanges();

            return Ok();
        }
    }
}
