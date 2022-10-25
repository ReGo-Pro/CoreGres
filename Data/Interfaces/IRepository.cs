using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Interfaces {
    public interface IRepository<TEntity, TIdentifier> where TEntity : class {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity FindById(TIdentifier ID);

        Task<IEnumerable<TEntity>> FindAllAsync();
    }
}
