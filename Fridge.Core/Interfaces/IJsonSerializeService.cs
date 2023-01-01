using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.Interfaces
{
    public interface IJsonSerializeService<T> where T : BaseDTO
    {
        Task<List<T>> ResponseAsync(string url);
        Task<bool> PostResponseWithDTOAsync(string url, T model);
        Task<bool> DeleteResponseASync(string url, Guid id);
    }
}
