using System;
using Cosourcing.RH.Domain.Societe;

namespace Cosourcing.RH.Contracts.Services.Societe
{
    public interface ISocieteService
    {
        public Task<int> Save(SocieteModel societe);

        
        public ValueTask<SocieteModel?> GetById(Guid id);

        public Task<SocieteModel[]> GetAll();

       
    }
}

