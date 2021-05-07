using Microsoft.EntityFrameworkCore;
using AdvertisementsService.API.DAL.DataBase.Entities;

namespace AdvertisementsService.API.DAL.DataBase.Contexts
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options) : base(options) { }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementURI> AdvertisementUris { get; set; }
        
    }
}
