namespace data.Interfaces {
    public interface IUnitOfWork {
        IAppSettingsRepository AppSettingsRepository { get; }
        Task CompleteAsync();    // TODO: This should become async
    }
}