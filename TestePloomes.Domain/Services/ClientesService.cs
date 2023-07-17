using TestePloomes.Data.Interfaces;
using TestePloomes.Data.Entidades;
using TestePloomes.Domain.Interfaces;
using TestePloomes.Domain.DTOS;

namespace TestePloomes.Domain.Services {
    public class ClientesService : IClientesService {

        private readonly IClientesRepository _clientesRepository;

        public ClientesService(IClientesRepository clientesRepository) {

            _clientesRepository = clientesRepository;
        }

        public async Task Alterar(ClientesDTO clientesDTO) {

            try {

                Validar(clientesDTO);

                var cliente = await _clientesRepository.GetById(clientesDTO.Id);

                if (cliente == null) {
                    throw new Exception("Cliente não encontrado!");
                }

                cliente.Nome = clientesDTO.Nome;
                cliente.Email = clientesDTO.Email;
                cliente.Cpf = clientesDTO.Cpf;
                cliente.LimiteCredito = clientesDTO.LimiteCredito;
                cliente.Endereco = clientesDTO.Endereco;

                _clientesRepository.Alterar(cliente);

                await SaveAllAsync();

            } catch (Exception) {

                throw;
            }
        }

        public async Task Excluir(int id) {

            try {

                var cliente = await _clientesRepository.GetById(id);

                if (cliente == null) {
                    throw new Exception("Cliente não encontrado!");
                }

                _clientesRepository.Excluir(cliente);

                await SaveAllAsync();

            } catch (Exception) {

                throw;
            }
        }

        public async Task Incluir(ClientesDTO clientesDTO) {

            try {

                Validar(clientesDTO);

                Clientes clientes = new Clientes {
                    Cpf = clientesDTO.Cpf,
                    Email = clientesDTO.Email,
                    Endereco = clientesDTO.Endereco,
                    LimiteCredito = clientesDTO.LimiteCredito,
                    Nome = clientesDTO.Nome
                };

                _clientesRepository.Incluir(clientes);

                await SaveAllAsync();

            } catch (Exception) {

                throw;
            }
        }

        public Task<bool> SaveAllAsync() {

            return _clientesRepository.SaveAllAsync();
        }

        public async Task<ClientesDTO> GetById(int id) {

            var cliente = await _clientesRepository.GetById(id);

            if (cliente != null) {

                ClientesDTO clientesDTO = new ClientesDTO {
                    Cpf = cliente.Cpf,
                    Email = cliente.Email,
                    Endereco = cliente.Endereco,
                    LimiteCredito = cliente.LimiteCredito,
                    Nome = cliente.Nome,
                    Id = cliente.Id
                };

                return clientesDTO;
            }

            throw new Exception("Cliente não encontrado!");
        }

        public async Task<IEnumerable<ClientesDTO>> SelecionarTodos() {

            var clientes = await _clientesRepository.SelecionarTodos();

            var clientesDTO = clientes.Select(cliente => new ClientesDTO {               
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email= cliente.Email,
                Endereco = cliente.Endereco,
                LimiteCredito = cliente.LimiteCredito
            });

            return clientesDTO;
        }

        private static void Validar(ClientesDTO clientesDTO) {

            if (!ValidacaoHelper.VerificaCPF(clientesDTO.Cpf))
                throw new Exception("CPF inválido.");

            if (!ValidacaoHelper.ValidarEmail(clientesDTO.Email.Trim()))
                throw new Exception("Email inválido.");
        }
    }
}
