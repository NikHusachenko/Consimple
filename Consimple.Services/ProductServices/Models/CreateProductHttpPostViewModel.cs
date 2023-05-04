namespace Consimple.Services.ProductServices.Models
{
    public class CreateProductHttpPostViewModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public ICollection<string> Categories { get; set; }
    }
}