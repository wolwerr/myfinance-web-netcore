
namespace myfinance_web_dotnet_infra.Interfaces.Base

{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Cadastrar(TEntity Entidade);
        void Excluir(int Id);
        List<TEntity> ListarRegistro();
        TEntity RetornarRegistro(int Id);
    }
}