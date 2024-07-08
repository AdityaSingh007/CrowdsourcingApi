
using SampleMinimalApi.Interface;

namespace SampleMinimalApi.HostedServices
{
    public class MessageProcessor : BackgroundService
    {
        private readonly ILogger<MessageProcessor> _logger;
        private readonly IMessageQueueHandler _messageQueueHandler;

        public MessageProcessor(ILogger<MessageProcessor> logger,
            IMessageQueueHandler messageQueueHandler)
        {
            _logger = logger;
            _messageQueueHandler = messageQueueHandler;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var message in _messageQueueHandler.ReadAllAsync()
            .WithCancellation(stoppingToken))
            {
                try
                {
                    Console.WriteLine($"Message processed by background service - {message}");
                }
                finally
                {

                }
            }
        }
    }
}
