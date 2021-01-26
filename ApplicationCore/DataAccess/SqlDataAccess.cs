using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Dapper;

namespace Infrastructure
{
    public class SqlDataAccess
    {

        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public  List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query<T>(sql, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public async Task<List<Beer>> LoadDataWithMultipleMapping(string sql)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var beersList = await connection.QueryAsync<Beer, Brand, ProductContainer, Beer>(sql: sql,
                    map: (beer, brand, container) =>
                    {
                        if (brand != null)
                        {
                            beer.Brand = brand;
                        }
                        if (container != null)
                        {
                            beer.Container = container;
                        }
                        return beer;
                    }, commandType: CommandType.StoredProcedure);
                return beersList.ToList();
            }
        }

        public  async void SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
