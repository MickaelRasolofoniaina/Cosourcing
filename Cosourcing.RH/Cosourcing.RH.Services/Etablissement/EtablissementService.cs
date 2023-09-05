using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.Contracts.Services.Etablissement;
using Cosourcing.RH.Domain.Etablissement;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;

namespace Cosourcing.RH.Services.Etablissement
{
	public class EtablissementService : IEtablissementService
	{
		private readonly IBaseRepository _baseRepository;
		private readonly IEtablissementRepository _etablissementRepository;

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
            if (!Validator.EstRenseigne(etablissement)
            {
                
            }
        }

        public Task<int> Save(EtablissementModel etablissement)
        {
            ValidateData(etablissement);

            _baseRepository.Add(etablissement);

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

