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

        public void Complete() {
            _context.SaveChanges();
        }
    }
}
