using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.ServiceImpot
{
	public interface IServiceImpotRepository
	{
		public Task<ServiceImpotModel[]> GetAllServiceImpots();

		public Task<ServiceImpotModel[]> GetEtablissementServiceImpots(int idEtablissement);
    }
}

