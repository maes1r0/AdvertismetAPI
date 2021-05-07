using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementsService.API.BLL.DTO
{
    public class DefaultAdDTO : BaseEntityDTO
    {
        [StringLength(maximumLength:200)]
        public string AdTitle { get; set; }
        [StringLength(maximumLength:1000)]
        public string Description { get; set; }
        [MaxLength(3)]
        public List<AdUriDTO> ImageUriList { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
