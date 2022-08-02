using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")] // data anotattion
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")] // data anotattion    
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")] // data anotattion
        [MinLength(3)]
        [MaxLength(255)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório")] // data anotattion
        [Range(0,9999)]
        public long Stock { get; set; }
        public string? ImageURL { get; set; }
        public string? CategoryName { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    
    }
}
