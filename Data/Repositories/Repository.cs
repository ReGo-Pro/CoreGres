using data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace data.Repositories {
    public class Repository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier> where TEntity : class {
        private DbContext _context;

        public Repository(DbContext context) {
            _context = context;
        }

        public void Add(TEntity entity) {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities) {
            _context.AddRange(entities);
        }

        public TEntity FindById(TIdentifier ID) {
            var entity = _context.Find(typeof(TEntity), ID);
            if (entity == null) {
                return null;
            }

            return (TEntity)entity;
        }

        public void Remove(TEntity entity) {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            _context.RemoveRange(entities);
        }

        public IEnumerable<TEntity> FindAll() {
            return _context.Set<TEntity>().ToList();
        }

        protected virtual DbContext Context => _context;
    }
}
