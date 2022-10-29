namespace data.Interfaces {
    public interface IUnitOfWork : IDisposable {
        IAppSettingsRepository AppSettingsRepository { get; }
        Task CompleteAsync();    // TODO: This should become async
    }
}