using data.Interfaces;
using data.Repositories;

namespace data {
    public class UnitOfWork : IUnitOfWork {
        private AppDbContext _context;

        public IAppSettingsRepository AppSettingsRepository { get; }

        public UnitOfWork(AppDbContext DbContext) {
            _context = DbContext;
            AppSettingsRepository = new AppSettingsRepository(DbContext);
        }

        public async Task CompleteAsync() {
            await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context?.Dispose();
        }
    }
}
