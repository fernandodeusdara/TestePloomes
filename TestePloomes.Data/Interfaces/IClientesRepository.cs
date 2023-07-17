using TestePloomes.Data.Entidades;


namespace TestePloomes.Data.Interfaces {
    public interface IClientesRepository {

        void Incluir(Clientes clientes);
        void Alterar(Clientes clientes);
        void Excluir(Clientes clientes);
        Task<Clientes> GetById(int id);
        Task<IEnumerable<Clientes>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
