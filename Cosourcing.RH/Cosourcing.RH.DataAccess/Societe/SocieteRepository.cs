using System;
using Cosourcing.RH.Contracts.DataAccess.Societe;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain.Societe;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Societe
{
    public class SocieteRepository : ISocieteRepository
    {
        private DbSet<SocieteModel> _societeDbContext;

        public SocieteRepository(DbSet<SocieteModel> societeDbContext)
        {
            _societeDbContext = societeDbContext;
        }

        public Task<SocieteModel[]> GetAllSocietes()
        {
            return _societeDbContext.ToArrayAsync();
        }
    }
}