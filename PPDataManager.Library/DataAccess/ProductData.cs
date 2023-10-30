using Microsoft.Extensions.Configuration;
using PPDataManager.Library.Internal.DataAccess;
using PPDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDataManager.Library.DataAccess
{
    public class ProductData
    {
        private readonly IConfiguration _config;

        public ProductData(IConfiguration config)
        {
            _config = config;
        }
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "PPData");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "PPData").FirstOrDefault();

            return output;
        }
    }
}
