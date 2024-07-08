namespace SampleMinimalApi.Interface
{
    public interface IMessageQueueHandler
    {
        Task<bool> AddMessage(string message, CancellationToken cancellationToken = default);
        IAsyncEnumerable<string> ReadAllAsync(CancellationToken cancellationToken = default);
    }
}
