using GerenciarProdutos.Models;

namespace GerenciarProdutos.Services
{
    public class ProdutoService
    {
        private readonly List<Produto> _produtos = new();

        public ProdutoService()
        {
            _produtos.Add(new Produto { Id = 1, Nome = "Caneta", Preco = 2.50m, Categoria = "Papelaria" });
            _produtos.Add(new Produto { Id = 2, Nome = "Caderno", Preco = 15.00m, Categoria = "Papelaria" });
            _produtos.Add(new Produto { Id = 3, Nome = "Mochila", Preco = 89.90m, Categoria = "Acessórios" });
        }

        public List<Produto> ObterTodosProdutos() => _produtos;

        public Produto ObterProdutoPorId(int id) =>
            _produtos.FirstOrDefault(p => p.Id == id);

        // Métodos assíncronos para compatibilidade
        public Task<List<Produto>> ObterTodosProdutosAsync()
        {
            return Task.FromResult(_produtos);
        }
    }


}
