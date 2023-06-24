using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StocksController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [Route("~/api/stocks")]
        public async Task<IActionResult> GetStocks()
        {
            try
            {
                return Ok( await _stockRepository.GetStocks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("~/api/stocks/{productId:int}")]
        public async Task<IActionResult> GetStockQtyById(int productId)
        {
            try
            {
                Stock stock = await _stockRepository.GetStockById(productId);
                if (stock == null)
                    return NotFound();

                return Ok(stock.StockQty);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("~/api/stocks")]
        public async Task<IActionResult> UpdateStock([FromBody] List<Stock> items)
        {
            try
            {
                int totalItemUpdated = 0;
                List<int> listProductId = items.GroupBy(x => x.ProductId).Select(x=>x.Key).ToList();
                for(int i =0;i< listProductId.Count; i++)
                {
                    int productId = listProductId[i];
                    int totalItem = items.Count(x => x.ProductId == productId);
                    await _stockRepository.UpdateStockById(productId, totalItem);
                }
                return Ok(totalItemUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
