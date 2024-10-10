using Store.Core.Entites;
using Store.Core.Specifcations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Repos.Interfaces
{
    public interface IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifcations<TEntity, TKey> spec);
        Task<TEntity> GetWithSpecAsync(ISpecifcations<TEntity, TKey> spec);

        Task AddAsync(TEntity entity);

        Task<int>GetCountAsync(ISpecifcations<TEntity,TKey> spec);

        void Update(TEntity entity);
        void Delete(TEntity entity);


    }
}
