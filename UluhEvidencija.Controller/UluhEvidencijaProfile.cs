using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Controller.Models;

namespace UluhEvidencija.Controller
{
    public class UluhEvidencijaProfile : Profile
    {
        public UluhEvidencijaProfile()
        {
            #region Painting
            CreateMap<Painting, Contract.Models.Painting>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.PhotoPath))
                .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
                .ForMember(dest => dest.TechniqueID, opt => opt.MapFrom(src => src.TechniqueID))
                .ForMember(dest => dest.FormatID, opt => opt.MapFrom(src => src.FormatID))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Technique, opt => opt.Ignore())
                .ForMember(dest => dest.Format, opt => opt.Ignore())
                .ForMember(dest => dest.ExhibitionPaintings, opt => opt.Ignore())
                .ReverseMap();
            #endregion

            #region Author
            CreateMap<Author, Contract.Models.Author>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.DeathDate, opt => opt.MapFrom(src => src.DeathDate))
                .ForMember(dest => dest.ProfilePhotoPath, opt => opt.MapFrom(src => src.ProfilePhotoPath))
                .ForMember(dest => dest.Paintings, opt => opt.Ignore())
                .ReverseMap();
            #endregion
        }
    }
}
