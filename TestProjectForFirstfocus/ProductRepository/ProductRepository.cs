using Microsoft.Extensions.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestProjectForFirstfocus.ViewModel;

namespace TestProjectForFirstfocus.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string Url;
        public ProductRepository()
        {
            Url = "https://api.bestbuy.com/v1/products?apiKey=ExFNlAkCTKUdHusuItIv7oA4";
        }
        public IEnumerable<ProductVM> GetProducts()
        {
            XDocument xdoc = XDocument.Load(Url);
            var productList = (from e in xdoc.Root.Elements("product")
                               let r = e.Element("images")
                               let x = r.Elements("image").ElementAt(2)
                               let b = r.Elements("image").ElementAt(3)

                               select new ProductVM
                               {
                                   ProductSku = (int)e.Element("sku"),
                                   ProductName = (string)e.Element("name"),
                                   ProductPrice = (double)e.Element("regularPrice"),
                                   ProductsalePrice = (double)e.Element("salePrice"),
                                   onSale = (bool)e.Element("onSale"),
                                   customerReviewCount = (string)e.Element("customerReviewCount"),
                                   customerReviewAverage = (string)e.Element("customerReviewAverage"),
                                   ShortDescription = (string)e.Element("shortDescription"),
                                   thumbnailImage = (string)x.Element("href"),
                                   ThumbnailImageHeight = (int)x.Element("width"),
                                   ThumbnailImageWidth = (int)x.Element("height"),
                                   BiggerImage = (string)b.Element("href"),
                                   BiggerImageHeight = (int)b.Element("width"),
                                   BiggerImageWidth = (int)b.Element("height"),
                                   category = (string)e.Element("productTemplate")

                               }).ToList();
            return productList;
        }
        public IEnumerable<ProductVM> GetProductsDetail(int id)
        {
            var productDetai = (from d in GetProducts()
                                .Where(s => s.ProductSku == id)
                                select d);
            return productDetai;
        }

        public  IEnumerable<ProductVM> SearchProducts(string SearchValue)
        {
            var Search =(from m in GetProducts()
                          select m);
            if (!String.IsNullOrEmpty(SearchValue))
            {
                Search = Search.Where(s => s.ProductName.Contains(SearchValue));
            }
            return Search;
        }
    }
}
