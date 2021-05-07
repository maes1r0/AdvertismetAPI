using System;
using System.Collections.Generic;
using AdvertisementsService.API.DAL.DataBase.BaseEntities;

namespace AdvertisementsService.API.DAL.DataBase.Entities
{
    public class Advertisement: BaseEntity
    {
        public string AdTitle { get; set; }
        public string Description { get; set; }
        public List<AdvertisementURI> AdvertisementURIs { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
