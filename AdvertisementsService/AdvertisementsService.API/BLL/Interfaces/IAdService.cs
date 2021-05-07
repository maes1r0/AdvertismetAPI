using System.Collections.Generic;
using AdvertisementsService.API.BLL.DTO;

namespace AdvertisementsService.API.BLL.Interfaces
{
    public interface IAdService
    {
        IEnumerable<SmallPresAdDTO> GetAllAds(int page, string field = "", bool increasingDecreasing = true);
        IEnumerable<DefaultAdDTO> GetAllAds();
        object GetAd(int id, bool fields = false);
        bool CreateAd(DefaultAdDTO item);
    }
}
