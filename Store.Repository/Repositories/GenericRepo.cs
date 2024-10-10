using Microsoft.EntityFrameworkCore;
using Store.Core.Entites;
using Store.Core.Repos.Interfaces;
using Store.Core.Specifcations;
using Store.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class GenericRepo<TEntity, TKey> : IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepo(StoreDbContext context)
        {
            _context = context;
           
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Product)) 
            {
           return (IEnumerable<TEntity>) await _context.Products.Include(P => P.Brand).Include(P => P.Type).ToListAsync();
            }
          return await  _context.Set<TEntity>().ToListAsync();
        }


        public async Task<TEntity?> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products.Where(P => P.Id == id as int?).Include(P => P.Brand).Include(P => P.Type).FirstOrDefaultAsync() as TEntity;
            }
            return await _context.Set<TEntity>().FindAsync(id);
        }




        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifcations<TEntity,TKey> spec)
        {
          return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<TEntity> GetWithSpecAsync(ISpecifcations<TEntity, TKey> spec)
        {
           return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        private IQueryable<TEntity> ApplySpecifications(ISpecifcations<TEntity, TKey> spec)
        {
            return SpecificationEvaluator<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), spec);
        }



        public async Task AddAsync(TEntity entity)
        {
             await _context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            
        }

        public async Task<int> GetCountAsync(ISpecifcations<TEntity, TKey> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }
    }
}
