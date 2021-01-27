using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;

namespace ApplicationCore.Logic
{
    public static class ContainerLogic
    {
        public static List<ProductContainer> GetContainers(string connnectionString)
        {
            SqlDataAccess dataAccess = new SqlDataAccess(connnectionString);
            return dataAccess.LoadData<ProductContainer>(StoreProceduresList.SP_SELECT_ALL_CONTAINERS);
        }

        public static void SaveNewContainer(string connectionString, ProductContainer container)
        {
            SqlDataAccess dataAccess = new SqlDataAccess(connectionString);
            var newContainer = new { 
                @ContainerName = container.ContainerName, 
                @ContainerType = container.ContainerType, 
                @CapacityInOZ = container.CapacityInOz };
            dataAccess.SaveData(StoreProceduresList.SP_INSERT_NEW_CONTAINER, newContainer);
        }
    }
}
