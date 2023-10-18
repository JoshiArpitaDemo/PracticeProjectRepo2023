using PPDataManager.Library.Internal.DataAccess;
using PPDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            //TODO: Make this SOLID/DRY/Better
            // Start filling in the sale detail models we will save to the database
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate()/100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity

                };

                // Get the information about this product
                var productInfo = products.GetProductById(item.ProductId);

                if (productInfo == null )
                {
                    throw new Exception($"The product Id of {item.ProductId} could not be found in the database.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }
            // Create the Sale model
            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum( x=> x.PurchasePrice),
                Tax = details.Sum(x=> x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;


            // Save the sale model
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spSale_Insert", sale, "PPData");

            // Get the ID from the sale model
            sale.Id = sql.LoadData<int, dynamic>("spSale_Lookup", new { sale.CashierId, sale.SaleDate }, "PPData").FirstOrDefault();
            // Finish filling in the sale detail models
            foreach (var item in details)
            {
                item.SaleId = sale.Id;
                // Save the sale details models
                sql.SaveData("dbo.spSaleDetail_Insert", item, "PPData");
            }

           
        }
    }
}
