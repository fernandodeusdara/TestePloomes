using Microsoft.EntityFrameworkCore;
using TestePloomes.Data.Interfaces;
using TestePloomes.Data.Entidades;

namespace TestePloomes.Data.Repositories {
    public class ClientesRepository : IClientesRepository {

        private readonly TestePloomesContext _context;

        public ClientesRepository(TestePloomesContext context) {

            _context = context;
        }

        public void Alterar(Clientes clientes) {

            _context.Entry(clientes).State = EntityState.Modified;
        }

        public void Excluir(Clientes clientes) {
            
            _context.Clientes.Remove(clientes);
        }

        public void Incluir(Clientes clientes) {
            
            _context.Clientes.Add(clientes);
        }

        public async Task<bool> SaveAllAsync() {
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Clientes> GetById(int id) {

            return await _context.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Clientes>> SelecionarTodos() {

            return await _context.Clientes.ToListAsync();
        }
    }
}
