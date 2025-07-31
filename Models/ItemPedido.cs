using System.ComponentModel.DataAnnotations;

namespace GerenciarProdutos.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, 100, ErrorMessage = "A quantidade deve ser no mínimo 1.")]
        public int Quantidade { get; set; }

        public decimal Subtotal => Produto?.Preco * Quantidade ?? 0;
    }
}
