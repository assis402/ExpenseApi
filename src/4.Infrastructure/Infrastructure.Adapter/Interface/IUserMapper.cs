using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Infrastructure.Adapter.Interfaces
{
    public interface IUserMapper
    {
        User MapperToEntity(UserDTO userDTO);
        ICollection<UserDTO> MapperListUser(ICollection<User> user);
        UserDTO MapperToDTO(User user);
    }
}