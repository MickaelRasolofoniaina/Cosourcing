using System;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Societe;
using Cosourcing.RH.Contracts.Services.Societe;
using Cosourcing.RH.Domain.Societe;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;

namespace Cosourcing.RH.Services.Societe
{
    public class SocieteService : ISocieteService
    {
        private IBaseRepository _baseRepository;
        private ISocieteRepository _societeRepository;

        public SocieteService(
            IBaseRepository baseRepository,
            ISocieteRepository societeRepository
        )
        {
            _baseRepository = baseRepository;
            _societeRepository = societeRepository;
        }

        private static void ValidateData(SocieteModel societe)
        {
            if (!Validator.IsValidNomCommercial(societe.NomCommercial))
            {
                throw new InvalidModelDataException("Veuiller inserer un nom commercial valide !");
            }
        }
      

        public Task<int> Save(SocieteModel societe)
        {
           ValidateData(societe);

            _baseRepository.Add<SocieteModel>(societe);

            return _baseRepository.Commit();
        }

       /*
        public async Task<int> UpdateEmail(Guid id, string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new InvalidModelDataException("Email required");
            }

            var user = await _baseRepository.GetById<UserModel>(id);

            if (user != null)
            {
                user.Email = email;

                return await _baseRepository.Commit();
            }
            else
            {
                throw new EntityNotFoundException($"Cannot find user with {id}");
            }
        }
       */

        public ValueTask<SocieteModel?> GetById(Guid id)
        {
            return _baseRepository.GetById<SocieteModel>(id);
        }

        public Task<SocieteModel[]> GetAll()
        {
            return _societeRepository.GetAllSocietes();
        }
/*
        public Task<int> DeleteUser(Guid id)
        {
            _baseRepository.Delete<UserModel>(id);

            return _baseRepository.Commit();
        }
*/
    }
}

