﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;

namespace TwitterClone.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(RegisterDto dto);
    }
}
