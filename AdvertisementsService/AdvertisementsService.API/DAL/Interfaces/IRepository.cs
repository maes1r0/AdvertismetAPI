using System.Collections.Generic;
using System.Linq.Expressions;
using AdvertisementsService.API.DAL.DataBase.BaseEntities;
using System;

namespace AdvertisementsService.API.DAL.Interfaces
{
    public interface IRepository<TPrimaryEntity,TSlaveEntity> where TPrimaryEntity : BaseEntity where TSlaveEntity: BaseEntity
    {
        IEnumerable<TPrimaryEntity> GetAll(Expression<Func<TPrimaryEntity, List<TSlaveEntity>>> o);
        TPrimaryEntity Get( Expression<Func<TPrimaryEntity, List<TSlaveEntity>>> o, int id);
        void Create(TPrimaryEntity item);
    }
}
