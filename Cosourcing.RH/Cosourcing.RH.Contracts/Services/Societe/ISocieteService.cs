using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.Societe
{
    public interface ISocieteService
    {
        public Task<int> Save(SocieteModel societe);
  
        public ValueTask<SocieteModel?> GetById(int id);

        public Task<SocieteModel[]> GetAll();

        public Task<int> DeleteSociete(int id);
        public Task<bool> UpdateSociete(SocieteModel societe);
    }
}

