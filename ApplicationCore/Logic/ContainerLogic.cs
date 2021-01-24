using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure;
using System.Collections.Generic;

namespace ApplicationCore.Logic
{
    public static class ContainerLogic
    {
        public static List<ProductContainer> GetContainers(string connnectionString)
        {
            SqlDataAccess dataAccess = new SqlDataAccess(connnectionString);
            return dataAccess.LoadData<ProductContainer>(StoreProceduresList.SP_SELECT_ALL_CONTAINERS);
        }
    }
}
