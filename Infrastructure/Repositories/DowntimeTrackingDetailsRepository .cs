﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DowntimeTrackingDetailsRepository : GenericRepository<DowntimeTrackingDetails>, IDowntimeTrackingDetailsRepository
    {
        public DowntimeTrackingDetailsRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to DowntimeTrackingDetails if needed
    }
}