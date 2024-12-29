using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finshark.Dtos.Stock;
using finshark.Models;

namespace finshark.Interfaces
{
    #nullable enable
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockReqDto stockDto);
        Task<Stock?> DeleteAsync(int id);
    }
}