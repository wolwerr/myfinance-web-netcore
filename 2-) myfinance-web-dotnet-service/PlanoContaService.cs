using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {

        private readonly IPlanoContaRepository _planoContaRepository;

        public PlanoContaService(IPlanoContaRepository planoContaRepository){
            _planoContaRepository = planoContaRepository;
        }

        public void Cadastrar(PlanoConta Entidade)
        {
            _planoContaRepository.Cadastrar(Entidade);
        }

        public void Excluir(int Id)
        {
            _planoContaRepository.Excluir(Id);
        }
        public List<PlanoConta> ListarRegistro()
        {
            return _planoContaRepository.ListarRegistro();
        }
        public PlanoConta RetornarRegistro(int Id)
        {
            return _planoContaRepository.RetornarRegistro(Id);
        }
    }
}