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

        public async Task<TEntity> FindByIdAsync(TIdentifier ID) {
            var entity = await _context.FindAsync(typeof(TEntity), ID);
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

        public async Task<IEnumerable<TEntity>> FindAllAsync() {
            return await _context.Set<TEntity>().ToListAsync();
        }

        protected virtual DbContext Context => _context;
    }
}
