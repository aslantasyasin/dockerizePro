using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Basket.API.RabbitMQ
{
    public class RabbitMQMessagePublisher : IRabbitMQMessagePublisher
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public RabbitMQMessagePublisher(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Send<T>(T obj, string uri) where T : class
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(uri));
            await sendEndpoint.Send<T>(obj);
        }
    }
}
