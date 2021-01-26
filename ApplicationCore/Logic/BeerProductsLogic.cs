﻿using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Logic
{
    public static class BeerProductsLogic
    {

        public static async Task<List<Beer>> GetBeerProducts(string connectionString)
        {
            SqlDataAccess dat = new SqlDataAccess(connectionString);
            var result = await dat.LoadDataWithMultipleMapping(StoreProceduresList.SP_SELECT_ALL_BEERS);
            return result;
        }

        public static async Task<List<Beer>> GetThreeRandomBeerProducts(string connectionString)
        {
            int index;
            int shots = 0;
            List<int> lastshot = new List<int>();
            List<Beer> ThreeBeers = new List<Beer>();
            SqlDataAccess dat = new SqlDataAccess(connectionString);
            var result = await dat.LoadDataWithMultipleMapping(StoreProceduresList.SP_SELECT_ALL_BEERS);
            int totalProducts = result.Count;
            while (shots < 3)
            {
                index = new Random().Next(0, totalProducts);
                if (!lastshot.Contains(index))
                {
                    lastshot.Add(index);
                    ThreeBeers.Add(result.ElementAt(index));
                    shots++;
                }
            }
            return ThreeBeers;
        }

        public static void SaveBeerProduct(Beer beer, string connectionString)
        {
            var parameters = new
            {
                BrandId = beer.BrandId,
                ContainerId = beer.ContainerId,
                Price = beer.Price
            };
            SqlDataAccess sqlDataAccess = new SqlDataAccess(connectionString);
            sqlDataAccess.SaveData(StoreProceduresList.SP_INSERT_NEW_BEER_PRODUCT, parameters);
        }
    }
}
