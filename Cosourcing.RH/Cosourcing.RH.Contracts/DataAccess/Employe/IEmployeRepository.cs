using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.Employe
{
	public interface IEmployeRepository
	{
		public Task<EmployeModel[]> GetAllEmployes();

		public Task<EmployeModel[]> GetEtablissementEmployes(int idEtablissement);
    }
}

