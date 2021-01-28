using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Helpers
{
    public static class StoreProceduresList
    {
        /*BEERS*/
        public const string SP_SELECT_ALL_BEERS = "Sp_SelectAllBeers";
        public const string SP_INSERT_NEW_BEER_PRODUCT = "Sp_InsertNewBeerProduct";
        public const string SP_GET_BEER_BY_ID = "Sp_GetBeerProductById";
        /*BRANDS*/
        public const string SP_SELECT_ALL_BRANDS = "Sp_SelectAllBrands";
        public const string SP_INSERT_NEW_BRAND = "Sp_InsertNewBrand";
        /*CONTAINERS*/
        public const string SP_SELECT_ALL_CONTAINERS = "Sp_SelectAllContainers";
        public const string SP_INSERT_NEW_CONTAINER = "Sp_InsertNewContainer";
    }
}
