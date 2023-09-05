using System;
using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain.Etablissement;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Etablissement
{
	public class EtablissementRepository : IEtablissementRepository
	{
        private DbSet<EtablissementModel> _etablissementDbContext;

		public EtablissementRepository(DbSet<EtablissementModel> etablissementDbContext)
		{
            _etablissementDbContext = etablissementDbContext;
        }

        public Task<EtablissementModel[]> GetAllEtablissements()
        {
            return _etablissementDbContext.ToArrayAsync();
        }
    }
}

