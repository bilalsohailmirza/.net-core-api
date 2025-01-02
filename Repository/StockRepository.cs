using finshark.Data;
using finshark.Dtos.Stock;
using finshark.Interfaces;
using finshark.Models;
using Microsoft.EntityFrameworkCore;

namespace finshark.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public StockRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Stock>> GetAllAsync()
        {
            return await _dbContext.Stock.Include(s => s.Comments).ToListAsync();
        }
        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _dbContext.Stock.Include(s => s.Comments).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _dbContext.Stock.AddAsync(stockModel);
            await _dbContext.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock> DeleteAsync(int id)
        {
            var stockModel = await _dbContext.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }

            _dbContext.Stock.Remove(stockModel);
            await _dbContext.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock> UpdateAsync(int id, UpdateStockReqDto stockDto)
        {
            var existingStock = await _dbContext.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;

            await _dbContext.SaveChangesAsync();

            return existingStock;
        }

        public async Task<bool> StockExists(int id)
        {
            var stock = await _dbContext.Stock.FindAsync(id);
            // return await _dbContext.Stock.AnyAsync(s => s.Id == id);
            return stock != null;
        }
    }
}