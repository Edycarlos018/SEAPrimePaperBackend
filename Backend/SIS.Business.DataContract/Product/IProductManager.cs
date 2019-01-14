﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimePaper.Business.DataContract.Product
{
    public interface IProductManager
    {
        Task<bool> CreateProduct(ProductCreateDTO dto);
        Task<bool> EditProduct(ProductEditDTO dto);
        Task<bool> DeleteProduct(int id);
        Task<IEnumerable<ProductGetListItemDTO>> GetProducts(); //preexisting so no 
        Task<ProductGetListItemDTO> GetProductById(int id);
    }
}
