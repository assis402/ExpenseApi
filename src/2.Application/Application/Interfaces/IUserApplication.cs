using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserApplication
    {
        Task<ICollection<UserDTO>> GetAll();
        Task<UserDTO> Save(UserDTO userDTO);
        Task Update(UserDTO userDTO);
        Task Delete(DeleteUserDTO deleteUserDTO);
    }
}