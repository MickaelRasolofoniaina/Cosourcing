using System;
using Cosourcing.RH.Domain.Payement;

namespace Cosourcing.RH.Contracts.Services.Payement
{
	public interface IPayementService
	{
		public Task<int> Save(PayementModel payement);

        public ValueTask<PayementModel?> GetById(Guid id);

        public Task<PayementModel[]> GetAll();

        public Task<int> DeletePayement(Guid id);
    }
}

