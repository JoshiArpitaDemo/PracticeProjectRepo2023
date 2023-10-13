using PPDataManager.Library.DataAccess;
using PPDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET: Product
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();
            return data.GetProducts();
                
        }
    }
}