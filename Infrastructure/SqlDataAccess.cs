using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ApplicationCore.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
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

        public List<BeerProduct> LoadDataWithMultipleMapping(string sql)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var beersList = connection.Query<BeerProduct, Brand, Container, BeerProduct>(sql:sql, 
                    map: (beer,brand, container)=>{
                    beer.BrandName = brand.BrandName;
                    beer.ContainerName = container.ContainerName;
                    beer.ContainerType = container.ContainerType;
                        return beer;
                    }, commandType: CommandType.StoredProcedure).ToList();
                return beersList;
            }
        }

        public  void SaveDatsa<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }
    }
}
