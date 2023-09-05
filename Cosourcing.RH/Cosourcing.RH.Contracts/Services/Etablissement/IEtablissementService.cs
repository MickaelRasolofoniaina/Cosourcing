using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.Etablissement
{
	public interface IEtablissementService
	{
		public Task<int> Save(EtablissementModel etablissement);

        public ValueTask<EtablissementModel?> GetById(Guid id);

        public Task<EtablissementModel[]> GetAll();

        public Task<int> DeleteEtablissement(Guid id);
    }
}

