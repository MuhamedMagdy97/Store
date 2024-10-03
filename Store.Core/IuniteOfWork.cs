using Store.Core.Entites;
using Store.Core.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core
{
    public interface IuniteOfWork
    {
       Task<int> CompleteAsync();


        // Create repo<t> and return 

        IGenericRepo<TEnity, TKey> Repository<TEnity , TKey>() where TEnity : BaseEntity<TKey>;

    }
}
