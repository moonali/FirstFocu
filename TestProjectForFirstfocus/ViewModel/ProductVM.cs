using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectForFirstfocus.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }
        public int ProductSku { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double ProductsalePrice { get; set; }
        public string customerReviewCount { get; set; }
        public string customerReviewAverage { get; set; }
        public string ShortDescription { get; set; }
        public bool onSale { get; set; }
        public string thumbnailImage { get; set; }
        public int ThumbnailImageWidth { get; set; }
        public int ThumbnailImageHeight { get; set; }
        public string BiggerImage { get; set; }
        public int BiggerImageWidth { get; set; }
        public int BiggerImageHeight { get; set; }
        public string category { get; set; }

    }
}
