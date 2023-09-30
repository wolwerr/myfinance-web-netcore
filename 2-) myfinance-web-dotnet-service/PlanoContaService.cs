using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbContext;
        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        void Cadastrar(PlanoConta Entidade)
        {
            var dbSet = _dbContext.PlanoConta;

            if(Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else{
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        void Excluir(int Id)
        {
            var PlanoConta = new PlanoConta() { Id = Id };
            _dbContext.PlanoConta.Attach(PlanoConta);
            _dbContext.PlanoConta.Remove(PlanoConta);
            _dbContext.SaveChanges();

        }
        List<PlanoConta> ListarRegistro()
        {
            var dbSet = _dbContext.PlanoConta;
            return dbSet.ToList();
        }
        PlanoConta RetornarRegistro(int Id)
        {
            return _dbContext.PlanoConta.Where(x => x.Id == Id).First();
        }
    }
}