namespace Consimple.Web.Models.Category
{
    public class DemandedCategoriesHttpGetViewModel
    {
        public DemandedCategoriesHttpGetViewModel()
        {
            DemandedCategories = new List<IDictionary<string, int>>();
        }

        public ICollection<IDictionary<string, int>> DemandedCategories { get; set; }
    }
}