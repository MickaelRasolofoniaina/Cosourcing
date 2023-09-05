﻿using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.Societe
{
    public interface ISocieteService
    {
        public Task<int> Save(SocieteModel societe);
  
        public ValueTask<SocieteModel?> GetById(Guid id);

        public Task<SocieteModel[]> GetAll();

        public Task<int> DeleteSociete(Guid id);
    }
}

