using System;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.Contracts.Services.Etablissement;
using Cosourcing.RH.Domain.Etablissement;
using Cosourcing.RH.Domain.Exception;

namespace Cosourcing.RH.Services.Etablissement
{
	public class EtablissementService : IEtablissementService
	{
		private IBaseRepository _baseRepository;
		private IEtablissementRepository _etablissementRepository;

		public EtablissementService(
			IBaseRepository baseRepository,
			IEtablissementRepository etablissementRepository
		)
		{
			_baseRepository = baseRepository;
			_etablissementRepository = etablissementRepository;
		}

		private static void ValidateData(EtablissementModel etablissement)
		{
            if (etablissement.GetType() != typeof(EtablissementModel))
            {
                throw new InvalidModelDataException("Please enter a etablissement valid");
            }
        }

        public Task<int> Save(EtablissementModel etablissement)
        {
            ValidateData(etablissement);

            _baseRepository.Add<EtablissementModel>(etablissement);

			return _baseRepository.Commit();
        }



        public ValueTask<EtablissementModel?> GetById(Guid id)
        {
            return _baseRepository.GetById<EtablissementModel>(id);
        }

        public Task<EtablissementModel[]> GetAll()
        {
            return _etablissementRepository.GetAllEtablissements();
        }

        public Task<int> DeleteEtablissement(Guid id)
        {
            _baseRepository.Delete<EtablissementModel>(id);

            return _baseRepository.Commit();
        }
    }
}

