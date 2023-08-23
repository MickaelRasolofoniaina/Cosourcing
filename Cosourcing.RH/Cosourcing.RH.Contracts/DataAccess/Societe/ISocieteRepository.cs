using System;
using Cosourcing.RH.Domain.Societe;

namespace Cosourcing.RH.Contracts.DataAccess.Societe
{
    public interface ISocieteRepository
    {
        public Task<SocieteModel[]> GetAllSocietes();
    }
}
