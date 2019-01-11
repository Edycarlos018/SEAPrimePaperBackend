﻿using AutoMapper;
using PrimePaper.Database.Contexts;
using PrimePaper.Database.DataContract.Cart;
using PrimePaper.Database.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PrimePaper.Database.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly SISContext _context;
        private readonly IMapper _mapper;

        public CartRepository(SISContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateCartItem(CartCreateRAO rao)
        {
            var entity = _mapper.Map<CartEntity>(rao);

            // Don't let people buy less than 1 of a product
            if (entity.Quantity < 1)
            {
                return false;
            }

            // Don't let people buy products that don't exist
            if (!_context.ProductTableAccess.Any(x => x.ProductEntityId == entity.ProductEntityId))
            {
                return false;
            }

            // If the user already has some of this product in their cart, combine the new and old orders together
            if (_context.CartTableAccess.Any(x => x.OwnerId == entity.OwnerId && x.ProductEntityId == entity.ProductEntityId))
            {
                _context.CartTableAccess.Single(x => x.OwnerId == entity.OwnerId && x.ProductEntityId == entity.ProductEntityId).Quantity += entity.Quantity;
            }

            else
            {
                await _context.CartTableAccess.AddAsync(entity);
            }

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
