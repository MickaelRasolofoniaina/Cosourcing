using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.Etablissement
{
	public interface IEtablissementRepository
	{
		public Task<EtablissementModel[]> GetAllEtablissements();
    }
}

