using FacturacionApi.Dtos;

namespace FacturacionApi.Interfaces
{
    public interface IFac
    {
        List<FacturaDTO> GetAllFacts();
    }
}
