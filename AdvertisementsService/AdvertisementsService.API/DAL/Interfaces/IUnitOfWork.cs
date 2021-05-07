using AdvertisementsService.API.DAL.DataBase.Entities;

namespace AdvertisementsService.API.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Advertisement, AdvertisementURI> AdvertisementRepository { get; }
        void Save();
    }
}
