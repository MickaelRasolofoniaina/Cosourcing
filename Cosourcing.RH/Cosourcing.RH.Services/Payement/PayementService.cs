using System;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Payement;
using Cosourcing.RH.Contracts.Services.Payement;
using Cosourcing.RH.Domain.Payement;
using Cosourcing.RH.Domain.Exception;

namespace Cosourcing.RH.Services.Payement
{
	public class PayementService : IPayementService
	{
		private IBaseRepository _baseRepository;
		private IPayementRepository _payementRepository;

		public PayementService(
			IBaseRepository baseRepository,
			IPayementRepository payementRepository
		)
		{
			_baseRepository = baseRepository;
			_payementRepository = payementRepository;
		}

		private static void ValidateData(PayementModel payement)
		{
            if (payement.Montant > 0)
            {
                throw new InvalidModelDataException("Please enter a number positive");
            }
        }

        public Task<int> Save(PayementModel payement)
        {
            ValidateData(payement);

            _baseRepository.Add<PayementModel>(payement);

			return _baseRepository.Commit();
        }



        public ValueTask<PayementModel?> GetById(Guid id)
        {
            return _baseRepository.GetById<PayementModel>(id);
        }

        public Task<PayementModel[]> GetAll()
        {
            return _payementRepository.GetAllPayements();
        }

        public Task<int> DeletePayement(Guid id)
        {
            _baseRepository.Delete<PayementModel>(id);

            return _baseRepository.Commit();
        }
    }
}

