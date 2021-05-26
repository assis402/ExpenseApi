﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Core.Service;
using Domain.Entities;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _service;
        private readonly IUserMapper _mapper;

        public UserApplication(IUserService service, IUserMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ICollection<UserDTO>> GetAll()
        {
            var users = await _service.GetAll();
            return _mapper.MapperListUser(users);
        }

        public async Task<UserDTO> Save(UserDTO userDTO)
        {   
            User user = _mapper.MapperToEntity(userDTO);
            user = await _service.Save(user);
            return _mapper.MapperToDTO(user);
        }
    }
}