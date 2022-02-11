
namespace Microsoft.PowerOData.Service.Models
{
    public class ProductModel    
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string StandardCost { get; set; }
        public string ListPrice { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string ProductCategoryID { get; set; }
        public string ProductModelID { get; set; }
        public string SellStartDate { get; set; }
        public string SellEndDate { get; set; }
        public string DiscontinuedDate { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public string Rowguid { get; set; }
        public string ModifiedDate { get; set; }
    }
}
