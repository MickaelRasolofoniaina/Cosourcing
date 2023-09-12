using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.Etablissement
{
	public interface IEtablissementService
	{
		public Task<int> Save(EtablissementModel etablissement);

        public ValueTask<EtablissementModel?> GetById(int id);

        public Task<EtablissementModel[]> GetAll();

        public Task<int> DeleteEtablissement(int id);

        public Task<EtablissementModel[]> GetSocieteEtablissements(int idSociete);
    }
}

