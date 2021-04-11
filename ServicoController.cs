using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace ExemploInMemoryMeetingHangfire
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly ILogger _logger;
        public ServicoController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpPost("EnfileirarServicoUnico")]
        public ActionResult<string> EnfileirarServicoUnico()
        {
            try
            {
                var idServico = BackgroundJob.Enqueue<Servicos>(x => x.Servico1());
                _logger.Information("Serviço enfileirado com sucesso");

                return Ok(idServico);
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpPost("EnfileirarServicoEncadeado")]
        public ActionResult<string> EnfileirarServicoEncadeado()
        {
            try
            {
                var idServico = BackgroundJob.Enqueue<Servicos>(x => x.Servico1());
                BackgroundJob.ContinueJobWith<Servicos>(idServico, x => x.Servico2());

                _logger.Information("Serviço enfileirado com sucesso");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
