using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Logic
{
    public static class BrandsLogic
    {
        public static List<Brand> GetAllBrands(string connectionString)
        {
            SqlDataAccess dataAccess = new SqlDataAccess(connectionString);
            return dataAccess.LoadData<Brand>(StoreProceduresList.SP_SELECT_ALL_BRANDS);
        }
    }
}
