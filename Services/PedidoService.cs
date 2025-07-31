using GerenciarProdutos.Models;

namespace GerenciarProdutos.Services
{
    public class PedidoService
    {
        private readonly List<Pedido> _pedidos = new();
        private int _nextId = 1;

        private readonly ClienteService _clienteService;
        private readonly ProdutoService _produtoService;

        public PedidoService(ClienteService clienteService, ProdutoService produtoService)
        {
            _clienteService = clienteService;
            _produtoService = produtoService;

            // Populando com dados de exemplo
            var clientes = _clienteService.ObterTodosClientes();
            var produtos = _produtoService.ObterTodosProdutos();

            if (clientes.Any() && produtos.Any())
            {
                _pedidos.Add(new Pedido
                {
                    Id = _nextId++,
                    Cliente = clientes[0],
                    DataPedido = DateTime.Now.AddDays(-5),
                    Status = "Concluído",
                    Itens = new List<ItemPedido>
                {
                    new ItemPedido { Id = 1, Produto = produtos[0], Quantidade = 2 },
                    new ItemPedido { Id = 2, Produto = produtos[2], Quantidade = 1 }
                }
                });
            }
        }

        public Task<List<Pedido>> ObterTodosPedidosAsync()
        {
            return Task.FromResult(_pedidos.OrderByDescending(p => p.DataPedido).ToList());
        }

        public Task<Pedido?> ObterPedidoPorIdAsync(int id)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pedido);
        }

        public Task AdicionarPedidoAsync(Pedido pedido)
        {
            pedido.Id = _nextId++;
            pedido.DataPedido = DateTime.Now;

            // Garantir que Cliente seja corretamente atribuído
            if (pedido.Cliente == null && pedido.ClienteId != 0)
            {
                pedido.Cliente = _clienteService.ObterClientePorId(pedido.ClienteId);
            }

            _pedidos.Add(pedido);
            return Task.CompletedTask;
        }

        public Task AtualizarPedidoAsync(Pedido pedido)
        {
            var pedidoExistente = _pedidos.FirstOrDefault(p => p.Id == pedido.Id);

            if (pedidoExistente != null)
            {
                // Atualiza o cliente corretamente com base no ID
                if (pedido.ClienteId != 0)
                {
                    pedidoExistente.ClienteId = pedido.ClienteId;
                    pedidoExistente.Cliente = _clienteService.ObterClientePorId(pedido.ClienteId);
                }

                pedidoExistente.DataPedido = pedido.DataPedido;
                pedidoExistente.Status = pedido.Status;
                pedidoExistente.Itens = pedido.Itens;
            }

            return Task.CompletedTask;
        }

        public Task RemoverPedidoAsync(int id)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido != null)
            {
                _pedidos.Remove(pedido);
            }
            return Task.CompletedTask;
        }
    }

}
