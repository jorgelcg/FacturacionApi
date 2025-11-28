using FacturacionApi.Dtos;
using FacturacionApi.Interfaces;
using FacturacionApi.services;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturacionController : ControllerBase
    {
        private readonly ILogger<FacturacionController> _logger;
        private readonly IFac _factService;
      

        public FacturacionController(ILogger<FacturacionController> logger, IFac factService )
        {
            _logger = logger;
            _factService = factService;
        }
        

        [HttpGet]
        public  List<FacturaDTO> Get()
        {
            var facturas = _factService.GetAllFacts();
            return facturas;
        }
    }
}
