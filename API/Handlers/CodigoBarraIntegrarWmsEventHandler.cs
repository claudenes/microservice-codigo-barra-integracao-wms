using Domain.Interface.Service;
using MCar.EventBus.Abstractions;
using OpenTracing;
using System.Text.Json;

namespace API.Handlers
{
    public class CodigoBarraIntegrarWmsEventHandler : IntegrationEventHandler<CodigoBarraIntegrarWmsEvent>
    {
        private readonly IIntegracaoService _integracaoService;
        private readonly ILogger<CodigoBarraIntegrarWmsEventHandler> _logger;

        public CodigoBarraIntegrarWmsEventHandler(
            IIntegracaoService integracaoService,
            ILogger<CodigoBarraIntegrarWmsEventHandler> logger,
            ITracer tracer)
            : base(tracer)
        {
            _integracaoService = integracaoService;
            _logger = logger;
        }

        public async override Task Handle(CodigoBarraIntegrarWmsEvent @event)
        {
            string output = JsonSerializer.Serialize(@event);
            _logger.LogInformation($"Reading {@event.QueueName} queue. Values \n { output }");

            await _integracaoService.IntegrarCodigoBarra(@event.CodigoBarraIntegrar);
        }
    }
}
