using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.Societe
{
    public interface ISocieteRepository
    {
        public Task<SocieteModel[]> GetAllSocietes();
    }
}
