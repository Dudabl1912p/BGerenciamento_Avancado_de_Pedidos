namespace GerenciarProdutos.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public List<ItemPedido> Itens { get; set; } = new();
        public string Status { get; set; } = "Pendente";
        public decimal Total => Itens.Sum(item => item.Subtotal);
    }
}
