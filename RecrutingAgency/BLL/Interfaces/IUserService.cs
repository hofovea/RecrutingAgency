using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.DTO.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(string id);
        Task<UserDto> Add(CreateUserDto userToAdd);
        Task Update(string id, UpdateUserDto userToUpdate);
        Task Delete(string id);
        Task AddUserToRole(string userId, string role);
    }
}
