using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.Etablissement
{
	public interface IEtablissementRepository
	{
		public Task<EtablissementModel[]> GetAllEtablissements();

		public Task<EtablissementModel[]> GetSocieteEtablissements(int idSociete);
    }
}

