namespace data.Interfaces {
    public interface IUnitOfWork {
        IAppSettingsRepository AppSettingsRepository { get; }
        void Complete();    // TODO: This should become async
    }
}