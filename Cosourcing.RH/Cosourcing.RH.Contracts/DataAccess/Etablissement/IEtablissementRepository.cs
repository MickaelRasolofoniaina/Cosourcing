using System;
using Cosourcing.RH.Domain.Etablissement;

namespace Cosourcing.RH.Contracts.DataAccess.Etablissement
{
	public interface IEtablissementRepository
	{
		public Task<EtablissementModel[]> GetAllEtablissements();
    }
}

