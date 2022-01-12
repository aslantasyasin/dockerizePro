using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Basket.API.RabbitMQ
{
    public interface IRabbitMQMessagePublisher
    {
        Task Send<T>(T obj, string uri) where T : class;
    }
}
