using System.Collections.Generic;
using Application.DTO;
using Infrastructure.Adapter.Interfaces;
using Domain.Entities;

namespace Infrastructure.Adapter.Map
{
    public class UserMapper : IUserMapper
    {
        List<UserDTO> UserDTOs = new List<UserDTO>();

        public User MapperToEntity(UserDTO userDTO)
        {
            User User = new User
            (
                userDTO.Email,
                userDTO.Password,
                userDTO.Name
            );

            return User;
        }

        public ICollection<UserDTO> MapperListUser(ICollection<User> users)
        {
            foreach (var user in users)
            {
                UserDTO UserDTO = new UserDTO
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Password = user.Password,
                    Name = user.Name
                };

                UserDTOs.Add(UserDTO);
            }

            return UserDTOs;
        }

        public UserDTO MapperToDTO(User user)
        {
            UserDTO UserDTO = new UserDTO
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };

            return UserDTO;
        }
    }
}