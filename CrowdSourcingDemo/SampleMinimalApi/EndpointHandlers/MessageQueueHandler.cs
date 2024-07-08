using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleMinimalApi.Interface;

namespace SampleMinimalApi.EndpointHandlers
{
    public static class MessageQueueHandler
    {
        public static async Task<NoContent> AddMessage(
            IMessageQueueHandler messageQueueHandler,
            CancellationToken cancellationToken,
            [FromBody] string message)
        {
            await messageQueueHandler.AddMessage(message, cancellationToken);
            return TypedResults.NoContent();
        }
    }
}
