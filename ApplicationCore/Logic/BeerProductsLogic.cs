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
    public class BeerProductsLogic
    {
        private readonly string _connectionString;

        public BeerProductsLogic(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Beer>> GetBeerProducts()
        {
            SqlDataAccess dat = new SqlDataAccess(_connectionString);
            var result = await dat.LoadDataWithMultipleMapping(StoreProceduresList.SP_SELECT_ALL_BEERS);
            return result;
        }

        public async Task<List<Beer>> GetThreeRandomBeerProducts()
        {
            int index;
            int shots = 0;
            List<int> lastshot = new List<int>();
            List<Beer> ThreeBeers = new List<Beer>();
            SqlDataAccess dat = new SqlDataAccess(_connectionString);
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
    }
}
