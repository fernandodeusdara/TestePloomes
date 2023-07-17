using TestePloomes.Domain.DTOS;

namespace TestePloomes.Domain.Interfaces {
    public interface IClientesService {

        Task Incluir(ClientesDTO clientes);
        Task Alterar(ClientesDTO clientes);
        Task Excluir(int id);
        Task<ClientesDTO> GetById(int id);
        Task<IEnumerable<ClientesDTO>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
