﻿using Microsoft.Extensions.Configuration;
using PPDataManager.Library.Internal.DataAccess;
using PPDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDataManager.Library.DataAccess
{
    public class InventoryData
    {
        public InventoryData(IConfiguration config)
        {
            _config = config;
        }

        private readonly IConfiguration _config;

        public List<InventoryModel> GetInventory()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "PPData");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            sql.SaveData("dbo.spInventory_Insert", item, "PPData");

        }
    }
}
