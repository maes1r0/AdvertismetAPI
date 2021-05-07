
namespace AdvertisementsService.API.BLL.DTO
{
    public class SmallPresAdDTO : BaseEntityDTO
    {
        public string AdTitle { get; set; }
        public AdUriDTO ImageUri { get; set; }
        public decimal Price { get; set; }
    }
}
