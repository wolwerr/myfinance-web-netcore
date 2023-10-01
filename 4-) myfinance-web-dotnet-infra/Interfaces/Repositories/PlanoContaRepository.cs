using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra.Interfaces.Repositories
{
    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
        {

        }
    }
}