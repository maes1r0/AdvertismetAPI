using AdvertisementsService.API.DAL.Interfaces;
using AdvertisementsService.API.DAL.DataBase.Contexts;
using AdvertisementsService.API.DAL.DataBase.Entities;

namespace AdvertisementsService.API.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdvertisementContext context;
        private readonly IRepository<Advertisement, AdvertisementURI> adRepo;
        public UnitOfWork(AdvertisementContext context, IRepository<Advertisement, AdvertisementURI> adRepo)
        {
            this.context = context;
            this.adRepo = adRepo;
        }

        public IRepository<Advertisement, AdvertisementURI> AdvertisementRepository
        {
            get
            {
                return adRepo; 
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
