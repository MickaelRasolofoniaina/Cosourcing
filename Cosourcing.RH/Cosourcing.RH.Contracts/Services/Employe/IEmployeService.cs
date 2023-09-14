using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.Employe
{
	public interface IEmployeService
	{
		public Task<int> Save(EmployeModel employe);

        public ValueTask<EmployeModel?> GetById(int id);

        public Task<EmployeModel[]> GetAll();

        public Task<int> DeleteEmploye(int id);

        public Task<EmployeModel[]> GetEtablissementEmployes(int idEtablissement);
    }
}

