using SampleMinimalApi.Interface;
using System.Threading.Channels;

namespace SampleMinimalApi.Services
{
    public class MessageQueueHandler : IMessageQueueHandler
    {
        private const int MaxMessagesInChannel = 100;
        private readonly ILogger<MessageQueueHandler> _logger;
        private readonly Channel<string> _channel;

        public MessageQueueHandler(ILogger<MessageQueueHandler> logger)
        {
            _logger = logger;
            var options = new BoundedChannelOptions(MaxMessagesInChannel)
            {
                SingleWriter = false,
                SingleReader = true,
            };
            _channel = Channel.CreateBounded<string>(options);
        }

        public async Task<bool> AddMessage(string message, CancellationToken cancellationToken = default)
        {
            while (await _channel.Writer.WaitToWriteAsync(cancellationToken)
                && !cancellationToken.IsCancellationRequested)
            {
                if (_channel.Writer.TryWrite(message))
                {
                    _logger.LogInformation($"Message written: {message}");
                    return true;
                }
            }

            return false;
        }

        public IAsyncEnumerable<string> ReadAllAsync(CancellationToken cancellationToken = default) =>
            _channel.Reader.ReadAllAsync(cancellationToken);
    }
}
