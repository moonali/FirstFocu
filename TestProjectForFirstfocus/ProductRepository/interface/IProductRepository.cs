using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectForFirstfocus.ViewModel;

namespace TestProjectForFirstfocus.ProductRepository
{
    public interface IProductRepository
    {
        IEnumerable<ProductVM> GetProducts();
        IEnumerable<ProductVM> SearchProducts(string? Value);
    }
}
