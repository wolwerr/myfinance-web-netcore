using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;
        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        void Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;

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
            var Transacao = new Transacao() { Id = Id };
            _dbContext.Transacao.Attach(Transacao);
            _dbContext.Transacao.Remove(Transacao);
            _dbContext.SaveChanges();

        }
        List<Transacao> ListarRegistro()
        {
            var dbSet = _dbContext.Transacao;
            return dbSet.ToList();
        }
        Transacao RetornarRegistro(int Id)
        {
            return _dbContext.Transacao.Where(x => x.Id == Id).First();
        }
    }
}