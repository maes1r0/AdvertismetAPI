using System.Collections.Generic;

namespace AdvertisementsService.API.BLL.DTO
{
    public class OptionalPresAdDTO : BaseEntityDTO
    {
        public string AdTitle { get; set; }
        public string Description { get; set; }
        public List<AdUriDTO> AdvertisementURIs { get; set; }
        public decimal Price { get; set; }
    }
}
