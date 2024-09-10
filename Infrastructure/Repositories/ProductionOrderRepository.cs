﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductionOrderRepository : GenericRepository<ProductionOrder>, IProductionOrderRepository
    {
        public ProductionOrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ProductionOrder> GetProductionOrderWithDetailsByIdAsync(long id)
        {
            return await _context.ProductionOrder
        .Include(po => po.WeightCheck)
            .ThenInclude(wc => wc.ProductMaster)
        .Include(po => po.WeightCheck)
            .ThenInclude(wc => wc.ShiftMaster)   
        .Include(po => po.AttributeCheck)
            .ThenInclude(ac => ac.ProductMaster) 
        .Include(po => po.PreCheckListEntity)
            .ThenInclude(pc => pc.ProductMaster)
        .Include(po => po.PreCheckListEntity)
            .ThenInclude(pc => pc.ShiftMaster)
        .Include(po => po.PostCheckListEntity)
            .ThenInclude(pc => pc.ProductMaster)
        .Include(po => po.PostCheckListEntity)
            .ThenInclude(pc => pc.ShiftMaster) 
        .FirstOrDefaultAsync(po => po.Id == id);
        }
    }
}
