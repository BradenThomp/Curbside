using Dapper;
using Npgsql;
using ProductService.Models;
using System;
using System.Threading.Tasks;

namespace ProductService.Persistence
{
    public class ProductContext
    {
        public async Task InsertProduct(Product product)
        {
            string sql = "INSERT INTO product (id, external_id, product_name, price) Values (@SystemId, @ExternalId, @Name, @Price)";

            using (var connection = new NpgsqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, product);
            }
        }
    }
}
