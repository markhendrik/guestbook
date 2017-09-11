using AutoMapper;
using GuestBook.Dto;
using GuestBook.Models;
using System.Data.Entity;

namespace GuestBook
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Creating mapping association between model classes and their Data Transfer Objects. 
        /// </summary>
        public MappingProfile()
        {
            Mapper.CreateMap<Guest, NewGuestDto>();
            Mapper.CreateMap<NewGuestDto, Guest>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<NewEventDto, Event>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}