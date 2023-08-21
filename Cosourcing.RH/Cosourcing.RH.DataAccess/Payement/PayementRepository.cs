using System;
using Cosourcing.RH.Contracts.DataAccess.Payement;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain.Payement;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Payement
{
	public class PayementRepository : IPayementRepository
	{
        private DbSet<PayementModel> _payementDbContext;

		public PayementRepository(DbSet<PayementModel> payementDbContext)
		{
            _payementDbContext = payementDbContext;
        }

        public Task<PayementModel[]> GetAllPayements()
        {
            return _payementDbContext.ToArrayAsync();
        }
    }
}

