using System;
using AdvertisementsService.API.DAL.DataBase.BaseEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementsService.API.DAL.DataBase.Entities
{
    public class AdvertisementURI : BaseEntity
    {
        public string Uri { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
