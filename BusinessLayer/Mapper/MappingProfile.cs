﻿using AutoMapper;
using EntityLayer.Concrete.DTOs.BlogDTOs;
using EntityLayer.Concrete.DTOs.CarDTOs;
using EntityLayer.Concrete.DTOs.CommentDTOs;
using EntityLayer.Concrete.TableModels;

namespace BusinessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Blog
            CreateMap<BlogCreateDto, Blog>().ReverseMap();
            CreateMap<BlogUpdateDto, Blog>().ReverseMap();
            CreateMap<BlogReadDto, Blog>().ReverseMap();
            CreateMap<BlogReadActivDto, Blog>().ReverseMap();
            #endregion

            #region Comment
            CreateMap<CommentCreateDto, Comment>().ReverseMap();
            CreateMap<CommentReadDto , Comment>().ReverseMap();
            CreateMap<CommentReadActiveDto, Comment>().ReverseMap();
            #endregion

            #region Car
            CreateMap<CarCreateDTO , Car>().ReverseMap();
            CreateMap<CarReadActivDto , Car>().ReverseMap();
            CreateMap<CarReadDto , Car>().ReverseMap();
            CreateMap<CarUpdateDto , Car>().ReverseMap();
            #endregion
        }
    }
}
