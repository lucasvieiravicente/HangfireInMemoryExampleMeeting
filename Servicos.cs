using Microsoft.Extensions.Logging;
using System.Threading;

namespace ExemploInMemoryMeetingHangfire
{
    public class Servicos
    {
        private readonly ILogger<Servicos> _logger;
        public Servicos(ILogger<Servicos> logger)
        {
            _logger = logger;
        }

        public void Servico1()
        {
            _logger.LogInformation("Iniciando serviço número 1.");
            _logger.LogInformation("Processsando serviço número 1...");
            Thread.Sleep(3000);
            _logger.LogInformation("Finalizando serviço número 1.");
        }

        public void Servico2()
        {
            _logger.LogInformation("Iniciando serviço número 2.");
            _logger.LogInformation("Processsando serviço número 2...");
            Thread.Sleep(3000);
            _logger.LogInformation("Finalizando serviço número 2.");
        }
    }
}
