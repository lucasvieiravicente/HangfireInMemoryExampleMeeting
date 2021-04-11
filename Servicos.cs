using Serilog;
using System.Threading;

namespace ExemploInMemoryMeetingHangfire
{
    public class Servicos
    {
        private readonly ILogger _logger;
        public Servicos(ILogger logger)
        {
            _logger = logger;
        }

        public void Servico1()
        {
            _logger.Information("Iniciando serviço número 1.");
            _logger.Information("Processsando serviço número 1...");
            Thread.Sleep(3000);
            _logger.Information("Finalizando serviço número 1.");
        }

        public void Servico2()
        {
            _logger.Information("Iniciando serviço número 2.");
            _logger.Information("Processsando serviço número 2...");
            Thread.Sleep(3000);
            _logger.Information("Finalizando serviço número 2.");
        }
    }
}
