using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using AdvertisementsService.API.DAL.Interfaces;
using AdvertisementsService.API.DAL.DataBase.Contexts;
using AdvertisementsService.API.DAL.DataBase.BaseEntities;
using System.Collections.Generic;

namespace AdvertisementsService.API.DAL.Repository
{
    public class Repository<TPrimaryEntity, TSlaveEntity> : IRepository<TPrimaryEntity, TSlaveEntity> where TPrimaryEntity : BaseEntity where TSlaveEntity: BaseEntity
    {
        private readonly AdvertisementContext context;
        

        public Repository(AdvertisementContext context)
        {
            this.context = context;
        }

        public IEnumerable<TPrimaryEntity> GetAll(Expression<Func<TPrimaryEntity, List<TSlaveEntity>>> o)
        {
            
            return context.Set<TPrimaryEntity>().Include(o).AsEnumerable();
        }
        public TPrimaryEntity Get( Expression<Func<TPrimaryEntity, List<TSlaveEntity>>> o, int id)
        {
            if (context.Set<TPrimaryEntity>().Any(o => o.Id == id)) 
            {
                return context.Set<TPrimaryEntity>().Include(o).Where(o => o.Id == id).First();
            }
            else
            {
                return null;
            } 
        }
        public void Create(TPrimaryEntity item)
        {
            context.Set<TPrimaryEntity>().Add(item);
        }
    }
}
