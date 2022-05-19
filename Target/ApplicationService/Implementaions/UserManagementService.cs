using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementaions
{
    public class UserManagementService
    {
        public List<UserDTO> Get()
        {
            List<UserDTO> nationalitiesDto = new List<UserDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get())
                {

                    nationalitiesDto.Add(new UserDTO
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        Password = item.Password
                    });

                }
            }

            return nationalitiesDto;
        }

        public UserDTO GetById(int id)
        {
            UserDTO nationalityDTO = new UserDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User nationality = unitOfWork.UserRepository.GetByID(id);
                if (nationality != null)
                {
                    nationalityDTO = new UserDTO
                    {
                        Id = nationality.Id,
                        UserName = nationality.UserName,
                        Password = nationality.Password
                    };
                }
            }

            return nationalityDTO;
        }

        public bool Save(UserDTO nationalityDTO)
        {
            User nationality = new User()
            {
                UserName = nationalityDTO.UserName,
                Password = nationalityDTO.Password
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserRepository.Insert(nationality);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    User nationality = unitOfWork.UserRepository.GetByID(id);
                    unitOfWork.UserRepository.Delete(nationality);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
