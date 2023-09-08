using Cosourcing.RH.Contracts.DataAccess.Societe;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Societe
{
    public class SocieteRepository : ISocieteRepository
    {
        private readonly DbSet<SocieteModel> _societeDbContext;

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