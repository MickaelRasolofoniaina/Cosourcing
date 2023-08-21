using System;
using Cosourcing.RH.Domain.Payement;

namespace Cosourcing.RH.Contracts.DataAccess.Payement
{
	public interface IPayementRepository
	{
		public Task<PayementModel[]> GetAllPayements();
    }
}

