using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.ServiceImpot
{
	public interface IServiceImpotService
	{
		public Task<int> Save(ServiceImpotModel serviceImpot);

        public ValueTask<ServiceImpotModel?> GetById(int id);

        public Task<ServiceImpotModel[]> GetAll();

        public Task<int> DeleteServiceImpot(int id);

        public Task<ServiceImpotModel[]> GetEtablissementServiceImpots(int idEtablissement);
        public Task<bool> UpdateServiceImpot(ServiceImpotModel serviceImpot);
    }
}

