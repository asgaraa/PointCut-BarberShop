using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.DTOs.Pricing;
using ServiceLayer.DTOs.Salon;
using ServiceLayer.DTOs.Services;
using ServiceLayer.DTOs.Team;
using ServiceLayer.DTOs.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<Gallery, GalleryDto>().ReverseMap();
            CreateMap<Gallery, GalleryEditDto>().ReverseMap();
            CreateMap<HeroWrap, HeroWrapDto>().ReverseMap();
            CreateMap<HeroWrap, HeroWrapEditDto>().ReverseMap();
            CreateMap<Pricing, PricingDto>().ReverseMap();
            CreateMap<Pricing, PricingEditDto>().ReverseMap();
            CreateMap<Servis, ServicesDto>().ReverseMap();
            CreateMap<Servis, ServicesEditDto>().ReverseMap();
            CreateMap<Salon, SalonDto>().ReverseMap();
            CreateMap<Salon, SalonEditDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Team, TeamEditDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialEditDto>().ReverseMap();
        }
    }
}
