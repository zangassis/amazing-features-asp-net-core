using System.ComponentModel.DataAnnotations;
namespace AmazingFeatures.Models;
public class ProductDataAnnotation
{
    [Required(ErrorMessage = "The name is required.")]
    [StringLength(100, ErrorMessage = "The name must be at most 100 characters long.")]
    public string Name { get; set; }
}
