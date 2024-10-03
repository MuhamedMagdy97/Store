using Store.Core;
using Store.Core.Entites;
using Store.Core.Repos.Interfaces;
using Store.Repository.Data.Contexts;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class UniteOfWork : IuniteOfWork
    {
        private readonly StoreDbContext _context;

        private Hashtable _repos;

        public UniteOfWork(StoreDbContext context)
        {
            _context = context;
            _repos = new Hashtable();
        }
        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();


        public IGenericRepo<TEnity, TKey> Repository<TEnity, TKey>() where TEnity : BaseEntity<TKey>
        {
            var type = typeof(TEnity).Name;
            if (!_repos.ContainsKey(type))
            {
                var repo = new GenericRepo<TEnity, TKey>(_context);
                _repos.Add(type, repo);
            }
            return _repos[type] as IGenericRepo<TEnity, TKey>;
        }
    }
}
