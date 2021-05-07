using System;
using System.Linq;
using AutoMapper;
using AdvertisementsService.API.DAL.DataBase.BaseEntities;
using AdvertisementsService.API.DAL.DataBase.Entities;
using AdvertisementsService.API.BLL.DTO;
using System.Collections.Generic;

namespace AdvertisementsService.API.BLL.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BaseEntityDTO, BaseEntity>();

            CreateMap<BaseEntity, BaseEntityDTO>();

            CreateMap<AdUriDTO, AdvertisementURI>().IncludeBase<BaseEntityDTO, BaseEntity>();

            CreateMap<AdvertisementURI, AdUriDTO>();

            CreateMap<Advertisement, DefaultAdDTO>().ForMember(dto => dto.ImageUriList, conf => conf.MapFrom(o => o.AdvertisementURIs));

            CreateMap<Advertisement, SmallPresAdDTO>().IncludeBase<BaseEntity, BaseEntityDTO>().ForMember(dto => dto.ImageUri, conf => conf.MapFrom(o => o.AdvertisementURIs[0]));

            CreateMap<Advertisement, OptionalPresAdDTO>().IncludeBase<BaseEntity, BaseEntityDTO>();

            CreateMap<DefaultAdDTO, Advertisement>().IncludeBase<BaseEntityDTO, BaseEntity>();

            CreateMap<DefaultAdDTO, SmallPresAdDTO>().ForMember(dto => dto.ImageUri, obj => obj.MapFrom(d => d.ImageUriList[0]));

            CreateMap<SmallPresAdDTO, DefaultAdDTO>();

            CreateMap<AdvertisementURI, Uri>().ConvertUsing(s => new Uri(s.Uri));

            CreateMap<DefaultAdDTO, OptionalPresAdDTO>();

            CreateMap<BaseEntityDTO, SmallPresAdDTO>();
        }
    }
}
