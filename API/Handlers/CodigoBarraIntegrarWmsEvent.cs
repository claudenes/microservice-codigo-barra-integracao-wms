using Domain.DTO;
using MCar.EventBus.Events;

namespace API.Handlers
{
    public class CodigoBarraIntegrarWmsEvent : IntegrationEvent
    {
        public CodigoBarrasIntegrarDTO CodigoBarraIntegrar { get; set; }

        public CodigoBarraIntegrarWmsEvent(CodigoBarrasIntegrarDTO dto)
        {
            CodigoBarraIntegrar = dto;

            ExchangeName = "CodigoBarraIntegrarWms";
            ExchangeType = "direct";
            QueueName = "CodigoBarraIntegrarWmsEvent";
        }
    }
}
