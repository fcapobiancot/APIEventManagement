using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using EventManagement.BLL.Services.Contracts;
using EventManagement.DAL.Repositories.Contracts;
using EventManagement.DTO;
using EventManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace EventManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> ListUsers()
        {
            try
            {
                var queryUser = await this.userRepository.Consult();
                var userList = queryUser.Include(rol => rol.Role).ToList();

                return _mapper.Map<List<UserDTO>>(userList);
            }
            catch 
            {
                throw;
            }
        }

        public async Task<SessionDTO> validateCredentials(string email, string passoword)
        {
            try
            {
                var queryUser = await this.userRepository.Consult(u => u.Email == email && u.Password == passoword);
                if (queryUser.FirstOrDefault() == null)
                { 
                    throw new Exception("No existe el usuario");
                }
                 
                User returnUser = queryUser.Include(rol => rol.Role).First();

                return _mapper.Map<SessionDTO>(returnUser); 

            }
            catch
            {
                throw;
            }
        }

        public async Task<UserDTO> CreateUser(UserDTO model)
        {
            try
            {
                var userCreated = await this.userRepository.Create(_mapper.Map<User>(model));
                if (userCreated == null || userCreated.Id == 0)
                {
                    throw new Exception("No se pudo crear el usuario");
                }
                
                var query = await this.userRepository.Consult(u => u.Id == userCreated.Id);

                userCreated = query.Include(rol => rol.Role).First();

                return _mapper.Map<UserDTO>(userCreated);

            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales.";
                throw new Exception($"Error al crear el usuario: {ex.Message}. Detalles: {innerException}");
            }
        }

        public async Task<bool> UpdateUser(UserDTO model)
        {
            try
            {
                var userModel = _mapper.Map<User>(model);
                var foundUser = await this.userRepository.Get(u => u.Id == userModel.Id);

                if (foundUser == null)
                {
                    throw new Exception("No existe el usuario");
                }

                foundUser.Name = userModel.Name;
                foundUser.Email = userModel.Email;
                foundUser.Password = userModel.Password;
                foundUser.RoleId = userModel.RoleId;
                foundUser.Socials = userModel.Socials;
                foundUser.ProfilePic = userModel.ProfilePic;

                bool answer = await this.userRepository.Update(foundUser);

                if (!answer)
                {
                    throw new Exception("No se pudo editar el usuario");
                }

                return answer;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var foundUser = await this.userRepository.Get(u => u.Id == id);
                if (foundUser == null)
                {
                    throw new Exception("No existe el usuario");
                }

                bool answer = await this.userRepository.Delete(foundUser);

                if (!answer)
                {
                    throw new Exception("No se pudo eliminar el usuario");
                }

                return answer;
            }
            catch
            {
                throw;
            }
        }
             


    }
}
