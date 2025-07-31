using GerenciarProdutos.Models;

namespace GerenciarProdutos.Services
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes = new();
        private int _nextId = 1;

        public ClienteService()
        {
            // Dados de exemplo
            _clientes.Add(new Cliente { Id = _nextId++, Nome = "João Silva", Email = "joao@email.com" });
            _clientes.Add(new Cliente { Id = _nextId++, Nome = "Maria Oliveira", Email = "maria@email.com" });
            _clientes.Add(new Cliente { Id = _nextId++, Nome = "Carlos Souza", Email = "carlos@email.com" });
        }

        public List<Cliente> ObterTodosClientes() => _clientes;

        public Cliente ObterClientePorId(int id) =>
            _clientes.FirstOrDefault(c => c.Id == id);

        public void AdicionarCliente(Cliente cliente)
        {
            cliente.Id = _nextId++;
            _clientes.Add(cliente);
        }

        // Métodos assíncronos para compatibilidade
        public Task<List<Cliente>> ObterTodosClientesAsync()
        {
            return Task.FromResult(_clientes);
        }

        public Task<Cliente> ObterClientePorIdAsync(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(cliente);
        }

        public Task AdicionarClienteAsync(Cliente cliente)
        {
            cliente.Id = _nextId++;
            _clientes.Add(cliente);
            return Task.CompletedTask;
        }
    }


}
