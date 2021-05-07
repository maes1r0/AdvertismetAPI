using System;
using System.Collections.Generic;
using AdvertisementsService.API.BLL.Interfaces;
using AdvertisementsService.API.BLL.DTO;
using AdvertisementsService.API.DAL.Interfaces;
using AdvertisementsService.API.DAL.DataBase.Entities;
using AdvertisementsService.API.BLL.Infrastructure;
using System.Linq;
using AutoMapper;

namespace AdvertisementsService.API.BLL.Services
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWork data;
        private readonly IMapper map;
        public AdService(IUnitOfWork data, IMapper map)
        {
            this.data = data;
            this.map = map;
        }

        public IEnumerable<SmallPresAdDTO> GetAllAds(int page, string field="", bool increasingDecreasing=true)
        {
            IEnumerable<DefaultAdDTO> temp = map.Map<IEnumerable<DefaultAdDTO>>(data.AdvertisementRepository.GetAll(o => o.AdvertisementURIs));
            Pagination pag = new Pagination(temp.Count(), page);
            if (pag.IsValid)
            {
                if (field.ToLower() == "price")
                {
                    return map.Map<IEnumerable<SmallPresAdDTO>>(SortByPrice(temp.Skip(pag.PageSize * (pag.PageNumber - 1)).Take(pag.PageSize), increasingDecreasing));
                }
                else if (field.ToLower() == "creationdate")
                {
                    return map.Map<IEnumerable<SmallPresAdDTO>>(SortByCreationDate(temp.Skip(pag.PageSize * (pag.PageNumber - 1)).Take(pag.PageSize), increasingDecreasing));
                }
                else
                {
                    return map.Map<IEnumerable<SmallPresAdDTO>>(temp.Skip(pag.PageSize * (pag.PageNumber - 1)).Take(pag.PageSize));
                }
            }
            return null;
        }
        public IEnumerable<DefaultAdDTO> GetAllAds()
        {
            return map.Map<IEnumerable<DefaultAdDTO>>(data.AdvertisementRepository.GetAll(o => o.AdvertisementURIs));
        }
        public object GetAd(int id, bool fields = false)
        {
            if(fields == true)
            {
                var temp = data.AdvertisementRepository.Get(o => o.AdvertisementURIs, id);
                return map.Map<OptionalPresAdDTO>(temp);
            }
            else
            {
                return map.Map<Advertisement, SmallPresAdDTO>(data.AdvertisementRepository.Get(o => o.AdvertisementURIs, id)); 
            }
            
        }
        public bool CreateAd(DefaultAdDTO item)
        {
            item.CreationDate = DateTime.Now;
            data.AdvertisementRepository.Create(map.Map<Advertisement>(item));
            data.Save();
            var temp1 = data.AdvertisementRepository.GetAll(o => o.AdvertisementURIs).Last();
            foreach (var i in item.ImageUriList)
            {
                i.AdvertisementId = map.Map<DefaultAdDTO>(temp1).Id;
                temp1.AdvertisementURIs.Add(map.Map<AdvertisementURI>(i));
            }
            data.Save();
            var temp = data.AdvertisementRepository.GetAll(o => o.AdvertisementURIs).ToList();
            return true;
        }
        private IEnumerable<DefaultAdDTO> SortByPrice(IEnumerable<DefaultAdDTO> collection, bool increasingDecreasing)
        {
            if (increasingDecreasing)
            {
                return collection.OrderBy(o => o.Price);
            }
            else
            {
                return collection.OrderByDescending(o => o.Price);
            }
        }
        private IEnumerable<DefaultAdDTO> SortByCreationDate(IEnumerable<DefaultAdDTO> collection, bool increasingDecreasing)
        {
            if (increasingDecreasing)
            {
                return collection.OrderBy(o => o.CreationDate).AsEnumerable();
            }
            else
            {
                return collection.OrderByDescending(o => o.CreationDate).AsEnumerable();
            }
        }
        
    }
}
