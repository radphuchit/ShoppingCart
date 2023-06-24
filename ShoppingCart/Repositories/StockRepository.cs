using Dapper;
using ShoppingCart.Data;
using ShoppingCart.Models; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public interface IStockRepository
    {
        public Task<IEnumerable<Stock>> GetStocks();
        public Task<Stock> GetStockById(int id);

        public Task<int> UpdateStockById(int productId, int newStockQty);

    }
    public class StockRepository : IStockRepository
    {
        private readonly DapperContext _dapperContext;
        public StockRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            string query = "SELECT * FROM Stocks";
            using (var connection = _dapperContext.CreateConnection())
            {
                var stocks = await connection.QueryAsync<Stock>(query);
                return stocks.ToList();
            }
        } 
        public async Task<Stock> GetStockById(int productId)
        {
            string query = "SELECT * FROM Stocks WHERE ProductId = @productId";
            using (var connection = _dapperContext.CreateConnection())
            {
                var stock = await connection.QueryFirstOrDefaultAsync<Stock>(query,new { productId }); 
                return stock;
            }
        }
        public async Task<int> UpdateStockById(int productId, int newStockQty)
        {
            string query = "UPDATE Stocks SET StockQty = ((SELECT SUM(StockQty) FROM Stocks WHERE ProductId = @productId) - @StockQty) WHERE ProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", productId, System.Data.DbType.Int32);
            parameters.Add("StockQty", newStockQty, System.Data.DbType.Int32);

            using (var connection = _dapperContext.CreateConnection())
            {
                var totalUpdated = await connection.ExecuteAsync(query, parameters);
                return totalUpdated;
            }
        }
    }
}
