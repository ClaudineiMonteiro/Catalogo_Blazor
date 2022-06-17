using System.ComponentModel.DataAnnotations;

namespace Catalogo_Blazor.Shared.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [MaxLength(100)]
        public string? Nome { get; set; }
        [MaxLength(200)]
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        [MaxLength(250)]
        public string? IamagemUrl { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}
