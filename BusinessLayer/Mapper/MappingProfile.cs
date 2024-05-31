using AutoMapper;
using EntityLayer.Concrete.DTOs.BlogDTOs;
using EntityLayer.Concrete.DTOs.BodyDTOs;
using EntityLayer.Concrete.DTOs.BrandDTOs;
using EntityLayer.Concrete.DTOs.CarDTOs;
using EntityLayer.Concrete.DTOs.CommentDTOs;
using EntityLayer.Concrete.DTOs.DoorDTOs;
using EntityLayer.Concrete.DTOs.FuelDTOs;
using EntityLayer.Concrete.DTOs.TransmissionDTOs;
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

            #region Brand
            CreateMap<BrandCreateDto, Brand>().ReverseMap();
            CreateMap<BrandReadDto, Brand>().ReverseMap();
            CreateMap<BrandUpdateDto, Brand>().ReverseMap();
            #endregion

            #region Body
            CreateMap<BodyCreateDto, Body>().ReverseMap();
            CreateMap<BodyReadDto, Body>().ReverseMap();
            CreateMap<BodyUpdateDto, Body>().ReverseMap();
            #endregion

            #region Door
            CreateMap<DoorCreateDto , Door>().ReverseMap();
            CreateMap<DoorReadDto , Door>().ReverseMap();
            CreateMap<DoorUpdateDto , Door>().ReverseMap();
            #endregion

            #region Fuel
            CreateMap<FuelCreateDto , Fuel>().ReverseMap();
            CreateMap<FuelReadDto , Fuel>().ReverseMap();
            CreateMap<FuelUpdateDto , Fuel>().ReverseMap();
            #endregion

            #region Transmission
            CreateMap<TransmissionCreateDto, Transmission>().ReverseMap();
            CreateMap<TransmissionReadDto, Transmission>().ReverseMap();
            CreateMap<TransmissionUpdateDto, Transmission>().ReverseMap();
            #endregion




        }
    }
}
